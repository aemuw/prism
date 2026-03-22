using MediatR;
using Prism.Application.Exceptions;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Auth.Commands.VerifyEmail
{
    public class VerifyEmailHandler : IRequestHandler<VerifyEmailCommand, bool> 
    {
        private readonly IUserRepository _userRepository;

        public VerifyEmailHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(VerifyEmailCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);

            if (user is null)
                throw new NotFoundException("Користувача не знайдено");

            var success = user.VerifyEmail(command.Code);

            if (!success)
                throw new ValidationException("Невірний або прострочений код верифікації");

            await _userRepository.UpdateAsync(user);
            return true;
        }
    }
}
