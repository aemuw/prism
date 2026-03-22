namespace Prism.Domain.Entities
{
    public class SavedArticle
    {
        public Guid UserId { get; private set; }
        public User? User { get; private set; }

        public Guid ArticleId { get; private set; }
        public Article? Article { get; private set; }

        public DateTime SavedAt { get; private set; }
        public string? Note { get; private set; }
        public bool IsRead { get; private set; }

        public SavedArticle(Guid userId, Guid articleId)
        {
            UserId = userId;
            ArticleId = articleId;
            SavedAt = DateTime.UtcNow;
            IsRead = false;
        }

        public void UpdateNote(string? note)
        {
            Note = note;
        }

        public void MarkAsRead()
        {
            IsRead = true;
        }
    }
}
