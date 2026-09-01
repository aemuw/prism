using MediatR;
using Prism.Application.DTOs.Sources;
using Prism.Domain.Interfaces;

namespace Prism.Application.Features.Sources.Queries.GetSources
{
    public class GetSourcesHandler : IRequestHandler<GetSourcesQuery, List<SourceResponse>>
    {
        private readonly ISourceRepository _sourceRepository;
        private readonly IUserSourceRepository _userSourceRepository;

        public GetSourcesHandler(
            ISourceRepository sourceRepository,
            IUserSourceRepository userSourceRepository)
        {
            _sourceRepository = sourceRepository;
            _userSourceRepository = userSourceRepository;
        }

        public async Task<List<SourceResponse>> Handle(GetSourcesQuery query, CancellationToken cancellationToken)
        {
            var sources = await _sourceRepository.GetActiveAsync();
            var result = new List<SourceResponse>();

            foreach (var source in sources)
            {
                var isSubscribed = await _userSourceRepository.ExistsAsync(query.UserId, source.Id);

                result.Add(new SourceResponse
                {
                    Id = source.Id,
                    Name = source.Name,
                    Description = source.Description,
                    Url = source.Url,
                    Type = source.Type.ToString(),
                    IsVerified = source.IsVerified,
                    IsSubscribed = isSubscribed
                });
            }

            return result;
        }
    }
}
