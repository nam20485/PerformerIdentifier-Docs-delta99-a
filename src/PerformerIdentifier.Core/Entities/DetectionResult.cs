namespace PerformerIdentifier.Core.Entities;

/// <summary>
/// Represents a face detection result from a single video frame.
/// </summary>
public class DetectionResult
{
    /// <summary>
    /// Gets or sets the bounding box (x, y, width, height) of the detected face.
    /// </summary>
    public required float[] BoundingBox { get; set; }

    /// <summary>
    /// Gets or sets the detection confidence score (0.0 to 1.0).
    /// </summary>
    public float Confidence { get; set; }

    /// <summary>
    /// Gets or sets the matched performer, or null if unknown.
    /// </summary>
    public Performer? MatchedPerformer { get; set; }

    /// <summary>
    /// Gets or sets the similarity score if a match was found.
    /// </summary>
    public float SimilarityScore { get; set; }

    /// <summary>
    /// Gets or sets the video timestamp of the detection.
    /// </summary>
    public TimeSpan Timestamp { get; set; }
}
