namespace Prism.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Slug { get; private set; } = string.Empty;

        public Tag(string name)
        {
            Name = name;
            Slug = GenerateSlug(name);
        }

        public void Update(string name)
        {
            Name = name;
            Slug = GenerateSlug(name);
            UpdateTimestamp();
        }

        private static string GenerateSlug(string name)
            => name.ToLower()
            .Replace(" ", "-")
            .Replace("#", "sharp");
    }
}
