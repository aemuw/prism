namespace Prism.Domain.Entities
{
    public class UserSource
    {
        public Guid UserId { get; private set; }
        public User? User { get; private set; }

        public Guid SourceId { get; private set; }
        public Source? Source { get; private set; }

        public DateTime SubscribedAt { get; private set; }
        public bool IsNotificationsEnabled { get; private set; }

        public UserSource(Guid userId, Guid sourceId)
        {
            UserId = userId;
            SourceId = sourceId;
            SubscribedAt = DateTime.UtcNow;
            IsNotificationsEnabled = true;
        }

        public void ToggleNotifications()
        {
            IsNotificationsEnabled = !IsNotificationsEnabled;
        }
    }
}
