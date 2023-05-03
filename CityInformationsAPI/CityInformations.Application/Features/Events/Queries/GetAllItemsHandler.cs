using AutoMapper;
using AutoMapper.QueryableExtensions;
using CityInformations.Application.Helpers.Interfaces;
using CityInformations.Shared.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CityInformations.Application.Features.Events.Queries
{
    public class GetAllItemsQuery : IRequest<IReadOnlyList<EventDto>>
    {

    }

    public class GetAllItemsHandler : IRequestHandler<GetAllItemsQuery, IReadOnlyList<EventDto>>
    {
        private readonly IMyDbContext myDbContext;
        private readonly IMapper mapper;

        public GetAllItemsHandler(IMyDbContext myDbContext,
            IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<EventDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            return await myDbContext.Events
                .AsNoTracking()
                .ProjectTo<EventDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
