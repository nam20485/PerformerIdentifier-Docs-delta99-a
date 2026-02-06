namespace PerformerIdentifier.Core.Interfaces;

/// <summary>
/// Defines the contract for face recognition (embedding generation and matching).
/// </summary>
public interface IFaceRecognitionService
{
    /// <summary>
    /// Generates a 512-dimensional face embedding from a cropped face image.
    /// </summary>
    /// <param name="faceImageData">Cropped face image bytes.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A 512-element float array representing the face embedding.</returns>
    Task<float[]> GenerateEmbeddingAsync(
        byte[] faceImageData,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Calculates cosine similarity between two face embeddings.
    /// </summary>
    /// <param name="embedding1">First embedding.</param>
    /// <param name="embedding2">Second embedding.</param>
    /// <returns>Similarity score between -1 and 1.</returns>
    float CalculateSimilarity(float[] embedding1, float[] embedding2);
}
