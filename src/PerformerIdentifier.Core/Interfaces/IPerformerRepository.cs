using PerformerIdentifier.Core.Entities;

namespace PerformerIdentifier.Core.Interfaces;

/// <summary>
/// Defines the contract for performer data access operations.
/// </summary>
public interface IPerformerRepository
{
    /// <summary>
    /// Gets all enrolled performers.
    /// </summary>
    Task<IReadOnlyList<Performer>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a performer by ID.
    /// </summary>
    Task<Performer?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new performer.
    /// </summary>
    Task<Performer> AddAsync(Performer performer, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing performer.
    /// </summary>
    Task UpdateAsync(Performer performer, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a performer by ID.
    /// </summary>
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
