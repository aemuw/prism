using Prism.Domain.Enums;

namespace Prism.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; private set; } = string.Empty;
        public string? Body { get; private set; }
        public string Url { get; private set; } = string.Empty;
        public string? Author { get; private set; }
        public string? AiSummary { get; private set; }
        public ArticleStatus Status { get; private set; }
        public DateTime PublishedAt { get; private set; }

        public Guid SourceId { get; private set; }
        public Source? Source { get; private set; }
        
        public ICollection<Tag> Tags { get; private set; } = new List<Tag>();
        public ICollection<SavedArticle> SavedArticles { get; private set; } = new List<SavedArticle>();

        public Article(string title, string url, DateTime publishedAt, Guid sourceId)
        {
            Title = title;
            Url = url;
            PublishedAt = publishedAt;
            SourceId = sourceId;
            Status = ArticleStatus.Pending;
        }

        public void SetAiSummary(string summary)
        {
            AiSummary = summary;
            Status = ArticleStatus.Completed;
            UpdateTimestamp();
        }

        public void SetProcessing()
        {
            Status = ArticleStatus.Processing;
            UpdateTimestamp();
        }

        public void SetFailed()
        {
            Status = ArticleStatus.Failed;
            UpdateTimestamp();
        }

        public void AddTag(Tag tag)
        {
            if (!Tags.Contains(tag))
                Tags.Add(tag);
            UpdateTimestamp();
        }

        public void SetBody(string body)
        {
            Body = body;
            UpdateTimestamp();
        }
    }
}
