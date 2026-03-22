using MediatR;

namespace Prism.Application.Features.Auth.Commands.VerifyEmail
{
    public record VerifyEmailCommand(
        string Email,
        string Code
    ) : IRequest<bool>;
}
