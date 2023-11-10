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
        public async Task<Unit> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
