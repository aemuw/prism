namespace Prism.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendVerificationEmailAsync(string email, string username, string code);
    }
}
