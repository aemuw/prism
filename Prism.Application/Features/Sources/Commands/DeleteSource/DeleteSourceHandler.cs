using MediatR;
using Prism.Application.Exceptions;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Sources.Commands.DeleteSource
{
    public class DeleteSourceHandler : IRequestHandler<DeleteSourceCommand, bool>
    {
        private readonly ISourceRepository _sourceRepository;

        public DeleteSourceHandler(ISourceRepository sourceRepository)
        {
            _sourceRepository = sourceRepository;
        }

        public async Task<bool> Handle(DeleteSourceCommand command, CancellationToken cancellationToken)
        {
            var source = await _sourceRepository.GetByIdAsync(command.SourceId);

            if (source is null)
                throw new NotFoundException("Джерело не знайдено!");

            source.Deactivate();
            await _sourceRepository.UpdateAsync(source);

            return true;
        }
    }
}
