using MediatR;
using Prism.Application.DTOs.Users;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<UserProfileResponse>>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserProfileResponse>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(u => new UserProfileResponse
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Role = u.Role.ToString(),
                IsEmailVerified = u.IsEmailVerified,
                IsBlocked = u.IsBlocked,
                CreatedAt = u.CreatedAt
            }).ToList();
        }
    }
}
