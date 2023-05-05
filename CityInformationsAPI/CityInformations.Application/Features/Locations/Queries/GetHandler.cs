using AutoMapper;
using CityInformations.Application.Exceptions;
using CityInformations.Application.Helpers.Interfaces;
using CityInformations.Domain.Entities;
using CityInformations.Domain.Exceptions;
using CityInformations.Shared.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CityInformations.Application.Features.Locations.Queries
{
    public class GetQuery : IRequest<LocationDto>
    {
        public int Id { get; private set; }

        public GetQuery(int id)
        {
            Id = id;
        }
    }

    public class GetHandler : IRequestHandler<GetQuery, LocationDto>
    {
        private readonly IMyDbContext myDbContext;
        private readonly IMapper mapper;

        public GetHandler(IMyDbContext myDbContext,
            IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }

        public async Task<LocationDto> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                throw new GivenIdEqualsZero();
            }

            var entity = await myDbContext.Locations
                .Include(x => x.LocationDates)
                    .ThenInclude(y => y.TypeDate)
                    .ThenInclude(z => z.Descr)
                .Include(x => x.ObjectLocation)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundExceptionById(request.Id);
            }

            return MapObjectWithChilds(entity);
        }

        private LocationDto MapObjectWithChilds(Location entity)
        {
            var dto = mapper.Map<LocationDto>(entity);

            if (entity.LocationDates?.Count > 0)
            {
                dto.Dates = entity.LocationDates.Select(x => mapper.Map<LocationDateDto>(x)).ToList();
            }

            return dto;
        }
    }
}
