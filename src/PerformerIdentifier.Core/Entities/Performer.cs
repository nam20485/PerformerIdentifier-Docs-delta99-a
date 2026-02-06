namespace PerformerIdentifier.Core.Entities;

/// <summary>
/// Represents a performer with a stored face embedding for recognition.
/// </summary>
public class Performer
{
    /// <summary>
    /// Gets or sets the unique identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the performer's display name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the serialized 512-dimensional face embedding.
    /// </summary>
    public required byte[] Embedding { get; set; }

    /// <summary>
    /// Gets or sets the date the performer was enrolled.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the date the performer was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
