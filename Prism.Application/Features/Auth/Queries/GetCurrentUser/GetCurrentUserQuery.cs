using MediatR;
using Prism.Application.DTOs.Users;

namespace Prism.Application.Features.Auth.Queries.GetCurrentUser
{
    public record GetCurrentUserQuery(
        Guid userId
    ) : IRequest<UserProfileResponse>;
}
