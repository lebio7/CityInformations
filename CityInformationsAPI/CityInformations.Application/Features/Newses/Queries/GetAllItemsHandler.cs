using AutoMapper;
using AutoMapper.QueryableExtensions;
using CityInformations.Application.Helpers;
using CityInformations.Application.Helpers.Interfaces;
using CityInformations.Application.Helpers.Responses;
using CityInformations.Shared.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CityInformations.Application.Features.Newses.Queries
{
    public class GetAllItemsQuery : IRequest<CollectionListWithPagination<NewsDto>>
    {
        public int Limit { get; set; }

        public int Offset { get; set; }

        public string Search { get; set; }

        public GetAllItemsQuery(int? limit,
            int? offset,
            string search)
        {
            Limit = limit.HasValue ? limit.Value : Constants.DefaultLimitNumber;
            Offset = offset.HasValue ? offset.Value : Constants.DefaultOffsetNumber;
            Search = search;
        }
    }

    public class GetAllItemsHandler : IRequestHandler<GetAllItemsQuery, CollectionListWithPagination<NewsDto>>
    {
        private readonly IMyDbContext myDbContext;
        private readonly IMapper mapper;

        public GetAllItemsHandler(IMyDbContext myDbContext,
            IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }

        public async Task<CollectionListWithPagination<NewsDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var query = myDbContext.News.Where(x =>
            (string.IsNullOrEmpty(request.Search) || x.Title.ToUpper().Contains(request.Search.Trim().ToUpper())));

            int total = query.Count();

            var results = await query.OrderBy(x => x.CreatedDate)
                .ThenBy(x => x.EventId)
                .ThenBy(x => x.Title)
                .Skip(request.Offset)
                .Take(request.Limit)
                .AsNoTracking()
                .ProjectTo<NewsDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CollectionListWithPagination<NewsDto>()
            {
                Results = results,
                Limit = request.Limit,
                Offset = request.Offset,
                Total = total
            };
        }
    }
}
