using octest.Domain.Constants;
using octest.Domain.Entities;

namespace octest.Domain.Repositories;

public interface IEventLogRepository
{
    Task AddAsync(EventLog eventLog, CancellationToken cancellationToken = default);
    Task<EventLog?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<(List<EventLog> Events, int TotalCount)> GetFilteredAsync(
    EventType? type = null, string? description = null,
    DateTime? startDate = null, DateTime? endDate = null,
    int page = 1, int pageSize = 50,
    CancellationToken cancellationToken = default);
    Task<List<EventLog>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken = default);
    Task<List<EventLog>> GetByFileIdAsync(Guid fileId,
        CancellationToken cancellationToken = default);
    Task<Dictionary<EventType, int>> GetEventStatisticsAsync(
        DateTime? startDate = null, DateTime? endDate = null,
        CancellationToken cancellationToken = default);
    Task DeleteOlderThanAsync(DateTime date,
        CancellationToken cancellationToken = default);
}
