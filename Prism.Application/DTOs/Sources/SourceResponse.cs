namespace Prism.Application.DTOs.Sources
{
    public class SourceResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Url { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool IsVerified { get; set; }
        public bool IsSubscribed { get; set; }
    }
}
