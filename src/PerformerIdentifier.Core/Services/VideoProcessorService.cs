using Microsoft.Extensions.Logging;
using PerformerIdentifier.Core.Entities;
using PerformerIdentifier.Core.Interfaces;

namespace PerformerIdentifier.Core.Services;

/// <summary>
/// Orchestrates the video processing pipeline: frame extraction, detection, and recognition.
/// </summary>
public class VideoProcessorService
{
    private readonly IVideoFrameExtractor _frameExtractor;
    private readonly IFaceDetectionService _detectionService;
    private readonly ILogger<VideoProcessorService> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="VideoProcessorService"/>.
    /// </summary>
    public VideoProcessorService(
        IVideoFrameExtractor frameExtractor,
        IFaceDetectionService detectionService,
        ILogger<VideoProcessorService> logger)
    {
        _frameExtractor = frameExtractor;
        _detectionService = detectionService;
        _logger = logger;
    }

    /// <summary>
    /// Processes a video file and returns detection results for each analyzed frame.
    /// </summary>
    /// <param name="videoPath">Path to the video file.</param>
    /// <param name="intervalSeconds">Seconds between frame samples.</param>
    /// <param name="progress">Optional progress reporter.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Collection of detection results across all frames.</returns>
    public async Task<IReadOnlyList<DetectionResult>> ProcessVideoAsync(
        string videoPath,
        double intervalSeconds = 1.0,
        IProgress<double>? progress = null,
        CancellationToken cancellationToken = default)
    {
        var metadata = await _frameExtractor.GetMetadataAsync(videoPath, cancellationToken);
        _logger.LogInformation("Processing video: {Path} ({Duration})", videoPath, metadata.Duration);

        var results = new List<DetectionResult>();
        var totalSeconds = metadata.Duration.TotalSeconds;

        for (var seconds = 0.0; seconds < totalSeconds; seconds += intervalSeconds)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var timestamp = TimeSpan.FromSeconds(seconds);
            var frameData = await _frameExtractor.ExtractFrameAsync(videoPath, timestamp, cancellationToken);
            var detections = await _detectionService.DetectFacesAsync(
                frameData, metadata.Width, metadata.Height, cancellationToken: cancellationToken);

            foreach (var detection in detections)
            {
                detection.Timestamp = timestamp;
            }

            results.AddRange(detections);
            progress?.Report(seconds / totalSeconds);
        }

        _logger.LogInformation("Processing complete: {Count} detections found", results.Count);
        return results;
    }
}
