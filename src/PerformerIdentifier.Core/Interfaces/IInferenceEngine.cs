namespace PerformerIdentifier.Core.Interfaces;

/// <summary>
/// Abstracts ONNX inference execution across different hardware providers.
/// </summary>
public interface IInferenceEngine : IDisposable
{
    /// <summary>
    /// Runs inference on the provided input tensor.
    /// </summary>
    /// <param name="inputData">Input tensor data.</param>
    /// <param name="inputShape">Shape of the input tensor.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Output tensor data.</returns>
    Task<float[]> RunAsync(
        float[] inputData,
        int[] inputShape,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the name of the active execution provider (e.g., "DirectML", "CPU").
    /// </summary>
    string ExecutionProvider { get; }
}
