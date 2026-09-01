using MediatR;
using Prism.Application.Exceptions;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Users.Commands.BlockUser
{
    public class BlockUserHandler : IRequestHandler<BlockUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public BlockUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(BlockUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(command.UserId);

            if (user is null)
                throw new NotFoundException("Користувача не знайдено");

            user.Block();
            await _userRepository.UpdateAsync(user);

            return true;
        }
    }
}
