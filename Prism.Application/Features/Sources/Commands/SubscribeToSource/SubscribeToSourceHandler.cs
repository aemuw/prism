using MediatR;
using Prism.Application.Exceptions;
using Prism.Domain.Entities;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Sources.Commands.SubscribeToSource
{
    public class SubscribeToSourceHandler : IRequestHandler<SubscribeToSourceCommand, bool>
    {
        private readonly ISourceRepository _sourceRepository;
        private readonly IUserSourceRepository _userSourceRepository;

        public SubscribeToSourceHandler(ISourceRepository sourceRepository, IUserSourceRepository userSourceRepository)
        {
            _sourceRepository = sourceRepository;
            _userSourceRepository = userSourceRepository;
        }

        public async Task<bool> Handle(SubscribeToSourceCommand command, CancellationToken cancellationToken)
        {
            var source = await _sourceRepository.GetByIdAsync(command.SourceId);

            if (source is null)
                throw new NotFoundException("Джерело не знайдено");

            var alreadySubscribed = await _userSourceRepository.ExistsAsync(command.UserId, command.SourceId);

            if (alreadySubscribed)
                throw new ValidationException("Ви вже підписані на це джерело");

            var userSource = new UserSource(command.UserId, command.SourceId);
            await _userSourceRepository.AddAsync(userSource);

            return true;
        }
    }
}
