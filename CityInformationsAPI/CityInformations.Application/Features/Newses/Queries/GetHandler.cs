using AutoMapper;
using CityInformations.Application.Exceptions;
using CityInformations.Application.Helpers.Interfaces;
using CityInformations.Domain.Entities;
using CityInformations.Domain.Exceptions;
using CityInformations.Shared.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CityInformations.Application.Features.Newses.Queries
{
    public class GetQuery : IRequest<NewsDto>
    {
        public int Id { get; private set; }

        public GetQuery(int id)
        {
            Id = id;
        }
    }
    public class GetHandler : IRequestHandler<GetQuery, NewsDto>
    {
        private readonly IMyDbContext myDbContext;
        private readonly IMapper mapper;

        public GetHandler(IMyDbContext myDbContext,
            IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }


        public async Task<NewsDto> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                throw new GivenIdEqualsZero();
            }

            var entity = myDbContext.News
                .Include(x => x.NewsDates)
                    .ThenInclude(y => y.TypeDate)
                    .ThenInclude(z => z.Descr)
                .Include(x => x.Event)
                .FirstOrDefault(x => x.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundExceptionById(request.Id);
            }


            return MapObjectWithChilds(entity);
        }

        private NewsDto MapObjectWithChilds(News entity)
        {
            var dto = mapper.Map<NewsDto>(entity);

            if (entity.NewsDates?.Count > 0)
            {
                dto.Dates = entity.NewsDates.Select(x =>
                {
                    var dateDto = mapper.Map<NewsDateDto>(x);

                    return dateDto;
                }).ToList();
            }

            return dto;
        }
    }
}
