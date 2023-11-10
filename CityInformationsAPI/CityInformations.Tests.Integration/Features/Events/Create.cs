using CityInformations.Application.Exceptions;
using CityInformations.Application.Features.Events.Commands;
using CityInformations.Shared.DTO;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace CityInformations.Tests.Integration.Features.Events
{
    public class Create : BaseSetUp
    {
        [Fact]
        public async Task When_Id_Is_Higher_Than_Zero_Then_Throw_Exception()
        {
            // arrange
            var handler = new CreateHandler();
            EventDto eventDto = new EventDto()
            {
                Id = 123,
                Name = "Test",
            };

            // act
            Func<Task> action = async () => await handler.Handle(new CreateCommand(eventDto), CancellationToken.None);

            // asert
            await action.Should().ThrowAsync<IdIsHigherThanZero>();
        }

        [Fact]
        public async Task When_Event_Is_Corrected_Then_Should_Add_Item_To_Database()
        {
            // arrange
            var handler = new CreateHandler();
            EventDto eventDto = new EventDto()
            {
                Id = 1,
                Name = "Test",
            };

            // act 
            await handler.Handle(new CreateCommand(eventDto), CancellationToken.None);

            // assert
            var addedItem = await DbContext.Events.FirstOrDefaultAsync(x => x.Id == 1);

            addedItem.Should().NotBeNull();
        }
    }
}
