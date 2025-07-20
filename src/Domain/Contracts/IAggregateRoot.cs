namespace Assessments.UserManagement.Domain.Contracts;

/// <summary>
///     The <see href="https://deviq.com/domain-driven-design/aggregate-pattern">aggregate root</see> is responsible for
///     controlling access to all the members of its aggregate.
/// </summary>
/// <remarks>
///     It's perfectly acceptable to have single-entity aggregates, in which case that entity is itself the root of its
///     aggregate. In addition to controlling access, the aggregate root is also responsible for ensuring the consistency
///     of the aggregate. This is why it is important to ensure that the aggregate root does not directly expose its
///     children, but rather controls access itself.
/// </remarks>
public interface IAggregateRoot;
