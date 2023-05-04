using AutoMapper;
using CityInformations.Application.Exceptions;
using CityInformations.Application.Helpers.Interfaces;
using CityInformations.Shared.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CityInformations.Application.Features.Dates.Queries
{
    public class GetByTypeDatesIdQuery : IRequest<IReadOnlyList<DateDto>>
    {
        public List<int> TypeDatesId { get; set; }
    }

    public class GetByTypeDatesIdHandler : IRequestHandler<GetByTypeDatesIdQuery, IReadOnlyList<DateDto>>
    {
        private readonly IMyDbContext myDbContext;
        private readonly IMapper mapper;

        public GetByTypeDatesIdHandler(IMyDbContext myDbContext,
            IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }


        public async Task<IReadOnlyList<DateDto>> Handle(GetByTypeDatesIdQuery request, CancellationToken cancellationToken)
        {
            if (request.TypeDatesId == null
                || request.TypeDatesId.Count == 0)
            {
                throw new CollectionsToGetAreEmptyOrNull();
            }

            // Get Newest Date if has duplicate
            var entites = await myDbContext.Dates
                .Include(x => x.TypeDate)
                    .ThenInclude(y => y.Descr)
                .Where(x => request.TypeDatesId.Contains(x.TypeDateId))
                .GroupBy(x => x.TypeDateId)
                .Select(g => g.OrderByDescending(x => x.Id).FirstOrDefault())
                .ToListAsync();

            return entites?.Select(x =>
            {
                return mapper.Map<DateDto>(x);
            }).ToList();
        }
    }
}
