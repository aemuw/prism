using MediatR;
using Prism.Application.Exceptions;
using Prism.Domain.Entities;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Sources.Commands.AddSource
{
    public class AddSourceHandler : IRequestHandler<AddSourceCommand, Guid>
    {
        private readonly ISourceRepository _sourceRepository;

        public AddSourceHandler(ISourceRepository sourceRepository)
        {
            _sourceRepository = sourceRepository;
        }

        public async Task<Guid> Handle(AddSourceCommand command, CancellationToken cancellationToken)
        {
            var exists = await _sourceRepository.ExistsAsync(command.Url);

            if (exists)
                throw new ValidationException("Це джерело вже додано");

            var source = new Source(
                command.Name,
                command.Url,
                command.Type,
                command.AddedByUserId);

            await _sourceRepository.AddAsync(source);

            return source.Id;
        }
    }
}
