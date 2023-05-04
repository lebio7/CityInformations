using AutoMapper;
using CityInformations.Application.Exceptions;
using CityInformations.Application.Helpers.Interfaces;
using CityInformations.Domain.Exceptions;
using CityInformations.Shared.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CityInformations.Application.Features.Dates.Queries
{
    public class GetQuery : IRequest<DateDto>
    {
        public int Id { get; private set; }

        public GetQuery(int id)
        {
            Id = id;
        }
    }

    public class GetHandler : IRequestHandler<GetQuery, DateDto>
    {
        private readonly IMyDbContext myDbContext;
        private readonly IMapper mapper;

        public GetHandler(IMyDbContext myDbContext,
            IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;

        }
        public async Task<DateDto> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                throw new GivenIdEqualsZero();
            }

            var entity = myDbContext.Dates
                .Include(x => x.TypeDate)
                    .ThenInclude(y => y.Descr)
                .FirstOrDefault(x => x.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundExceptionById(request.Id);
            }

            return mapper.Map<DateDto>(entity);
        }
    }
}
