using MediatR;
using Prism.Application.DTOs.Users;

namespace Prism.Application.Features.Users.Queries.GetUsers
{
    public record GetUsersQuery() : IRequest<List<UserProfileResponse>>;
}
