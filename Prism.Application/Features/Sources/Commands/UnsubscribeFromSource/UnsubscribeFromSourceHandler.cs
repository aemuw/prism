using MediatR;
using Prism.Application.Exceptions;
using Prism.Domain.Entities;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Sources.Commands.UnsubscribeFromSource
{
    public class UnsubscribeFromSourceHandler : IRequestHandler<UnsubscribeFromSourceCommand, bool>
    {
        private readonly ISourceRepository _sourceRepository;
        private readonly IUserSourceRepository _userSourceRepository;

        public UnsubscribeFromSourceHandler(ISourceRepository sourceRepository, IUserSourceRepository userSourceRepository)
        {
            _sourceRepository = sourceRepository;
            _userSourceRepository = userSourceRepository;
        }

        public async Task<bool> Handle(UnsubscribeFromSourceCommand command, CancellationToken cancellationToken)
        {
            var source = await _sourceRepository.GetByIdAsync(command.SourceId);

            if (source is null)
                throw new NotFoundException("Джерело не знайдено");

            var subscribed = await _userSourceRepository.ExistsAsync(command.UserId, command.SourceId);

            if (!subscribed)
                throw new ValidationException("Ви ще не підписані на це джерело");

            await _userSourceRepository.DeleteAsync(command.UserId, command.SourceId);

            return true;
        }
    }
}
