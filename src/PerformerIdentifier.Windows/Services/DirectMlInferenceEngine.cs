using PerformerIdentifier.Core.Interfaces;

namespace PerformerIdentifier.Windows.Services;

/// <summary>
/// ONNX inference engine using DirectML for GPU-accelerated execution on Windows.
/// </summary>
public class DirectMlInferenceEngine : IInferenceEngine
{
    /// <inheritdoc />
    public string ExecutionProvider => "DirectML";

    /// <inheritdoc />
    public Task<float[]> RunAsync(
        float[] inputData,
        int[] inputShape,
        CancellationToken cancellationToken = default)
    {
        // TODO: Implement DirectML inference via ONNX Runtime
        throw new NotImplementedException("DirectML inference not yet implemented.");
    }

    /// <inheritdoc />
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
