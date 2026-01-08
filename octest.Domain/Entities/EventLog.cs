using octest.Domain.Constants;

namespace octest.Domain.Entities;

public class EventLog
{
    public Guid Id { get; private set; }
    public EventType Type { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public Guid? UserId { get; private set; }
    public Guid? FileUploadId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public string? AdditionalData { get; private set; }

    private EventLog()
    {
    }

    public static EventLog Create(
        EventType type,
        string description,
        Guid? userId = null,
        Guid? fileUploadId = null,
        string? additionalData = null)
    {
        return new EventLog
        {
            Id = Guid.NewGuid(),
            Type = type,
            Description = description,
            UserId = userId,
            FileUploadId = fileUploadId,
            CreatedAt = DateTime.UtcNow,
            AdditionalData = additionalData
        };
    }
}
