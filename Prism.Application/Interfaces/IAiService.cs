namespace Prism.Application.Interfaces
{
    public interface IAiService
    {
        Task<string> GenerateSummaryAsync(string title, string? body);
    }
}
