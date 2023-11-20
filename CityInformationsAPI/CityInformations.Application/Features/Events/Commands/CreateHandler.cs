using AutoMapper;
using CityInformations.Application.Exceptions;
using CityInformations.Application.Helpers.Interfaces;
using CityInformations.Domain.Entities;
using CityInformations.Shared.DTO;
using MediatR;

namespace CityInformations.Application.Features.Events.Commands
{
    public class CreateCommand : IRequest<Unit>
    {
        public EventDto EventDto { get; private set; }

        public CreateCommand(EventDto eventDto)
        {
            EventDto = eventDto;
        }
    }
    public class CreateHandler : IRequestHandler<CreateCommand>
    {
        private readonly IMyDbContext myDbContext;
        private readonly IMapper mapper;

        public CreateHandler(IMyDbContext myDbContext,
            IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            if (request.EventDto == null)
            {
                throw new ObjectIsNull();
            }
            else if (request.EventDto.Id > 0)
            {
                throw new IdIsHigherThanZero();
            }

            var entity = mapper.Map<Event>(request.EventDto);
            myDbContext.Events.Add(entity);
            await myDbContext.SaveChangesAsync();
           
            return Unit.Value;
        }
    }
}
