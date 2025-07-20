using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Mediator;

namespace Assessments.UserManagement.Domain.Abstractions;

/// <summary>
///     An <see href="https://deviq.com/domain-driven-design/entity">Entity</see> is an object that has some intrinsic
///     identity, apart from the rest of its state. Even if its properties are the same as another instance of the same
///     type, it remains distinct because of its unique identity.
/// </summary>
/// <remarks>
///     Entities are responsible for encapsulating their state and behavior, ensuring consistent domain logic and data
///     integrity.
/// </remarks>
public abstract class Entity
{
    [Required]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public Guid Id { get; protected init; }

    /// <summary>
    ///     <see
    ///         href="https://learn.microsoft.com/en-us/ef/core/saving/concurrency?tabs=data-annotations#optimistic-concurrency">
    ///         Optimistic concurrency.
    ///     </see>
    /// </summary>
    [Required]
    [Timestamp]
    public byte[] Version { get; protected set; } = null!;

    #region Domain Events

    private readonly List<INotification> domainEvents = [];

    public IReadOnlyCollection<INotification> DomainEvents => domainEvents.AsReadOnly();

    public void AddDomainEvent(INotification eventItem) => domainEvents.Add(eventItem);

    public void ClearDomainEvents() => domainEvents.Clear();

    public void RemoveDomainEvent(INotification eventItem) => domainEvents.Remove(eventItem);

    #endregion

    #region Equality and Hashing

    public override bool Equals(object? obj) => obj is Entity other && Equals(other);

    private bool Equals(Entity other) => ReferenceEquals(this, other) || Id.Equals(other.Id);

    public override int GetHashCode() => Id.GetHashCode() ^ 31;

    #endregion
}
