using MediatR;
using Prism.Application.Exceptions;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Auth.Commands.Logout
{
    public class LogoutHandler : IRequestHandler<LogoutCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public LogoutHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(LogoutCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(command.UserId);

            if (user is null)
                throw new NotFoundException("Користувача не знайдено");

            user.RevokeRefreshToken();
            await _userRepository.UpdateAsync(user);

            return true;
        }
    }
}
