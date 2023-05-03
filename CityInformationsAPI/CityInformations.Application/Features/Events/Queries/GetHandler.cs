using AutoMapper;
using CityInformations.Application.Exceptions;
using CityInformations.Application.Helpers.Interfaces;
using CityInformations.Domain.Exceptions;
using CityInformations.Shared.DTO;
using MediatR;

namespace CityInformations.Application.Features.Events.Queries
{
    public class GetQuery : IRequest<EventDto>
    {
        public int Id { get; private set; }

        public GetQuery(int id)
        {
            Id = id;
        }
    }

    public class GetHandler : IRequestHandler<GetQuery, EventDto>
    {
        private readonly IMyDbContext myDbContext;
        private readonly IMapper mapper;

        public GetHandler(IMyDbContext myDbContext,
            IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }

        public async Task<EventDto> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                throw new GivenIdEqualsZero();
            }

            var entity = myDbContext.Events.FirstOrDefault(x => x.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundExceptionById(request.Id);
            }

            return mapper.Map<EventDto>(entity);
        }
    }
}
