using Prism.Domain.Enums;

namespace Prism.Domain.Entities
{
    public class Source : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public string Url { get; private set; } = string.Empty;
        public SourceType Type { get; private set; }
        public SourceStatus Status { get; private set; }
        public bool IsVerified { get; private set; }
        public int FailedFetchCount { get; private set; }
        public DateTime? LastFetchedAt { get; private set; }

        public Guid AddedByUserId { get; private set; }
        public User? AddedByUser { get; private set; }

        public ICollection<Article> Articles { get; private set; } = new List<Article>();
        public ICollection<UserSource> UserSources { get; private set; } = new List<UserSource>();

        public Source(string name, string url, SourceType type, Guid addedByUserId)
        {
            Name = name;
            Url = url;
            Type = type;
            AddedByUserId = addedByUserId;
            Status = SourceStatus.Active;
            IsVerified = false;
            FailedFetchCount = 0;
        }
        
        public void Update(string name, string? description)
        {
            Name = name;
            Description = description;
            UpdateTimestamp();
        }

        public void RecordFailedFetch()
        {
            FailedFetchCount++;

            if (FailedFetchCount >= 3)
                Status = SourceStatus.Failed;

            UpdateTimestamp();
        }

        public void Verify()
        {
            IsVerified = true;
            UpdateTimestamp();
        }

        public void Deactivate()
        {
            Status = SourceStatus.Inactive;
            UpdateTimestamp();
        }

        public void Activate()
        {
            Status = SourceStatus.Active;
            FailedFetchCount = 0;
            UpdateTimestamp();
        }
    }
}
