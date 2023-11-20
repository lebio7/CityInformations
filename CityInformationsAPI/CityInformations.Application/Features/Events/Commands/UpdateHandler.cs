using AutoMapper;
using CityInformations.Application.Exceptions;
using CityInformations.Application.Helpers.Interfaces;
using CityInformations.Domain.Exceptions;
using CityInformations.Shared.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CityInformations.Application.Features.Events.Commands
{
    public class UpdateCommand : IRequest<Unit>
    {
        public EventDto EventDto { get; private set; }

        public UpdateCommand(EventDto eventDto)
        {
            EventDto = eventDto;
        }
    }

    public class UpdateHandler : IRequestHandler<UpdateCommand>
    {
        private readonly IMyDbContext myDbContext;
        private readonly IMapper mapper;

        public UpdateHandler(IMyDbContext myDbContext,
            IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            Validate(request);

            var entity = await myDbContext.Events.FirstOrDefaultAsync(x => x.Id == request.EventDto.Id);

            entity = mapper.Map(request.EventDto, entity);

            await myDbContext.SaveChangesAsync();

            return Unit.Value;
        }

        private void Validate(UpdateCommand request)
        {
            if (request.EventDto == null)
            {
                throw new ObjectIsNull();
            }
            else if (request.EventDto.Id == 0)
            {
                throw new GivenIdEqualsZero();
            }
            else if (!myDbContext.Events.Any(x => x.Id == request.EventDto.Id))
            {
                throw new NotFoundException(request.EventDto.Id);
            }
        }
    }
}
