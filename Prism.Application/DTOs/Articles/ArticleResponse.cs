namespace Prism.Application.DTOs.Articles
{
    public class ArticleResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? AiSummary { get; set; }
        public string Url { get; set; } = string.Empty;
        public string? Author { get; set; }
        public string SourceName { get; set; } = string.Empty;
        public DateTime PublishedAt { get; set; }
        public List<string> Tags { get; set; } = new();
        public bool IsSaved { get; set; }
    }
}
