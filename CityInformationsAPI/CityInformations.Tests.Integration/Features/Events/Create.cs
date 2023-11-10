using AutoMapper;
using CityInformations.Application.Exceptions;
using CityInformations.Application.Features.Events.Commands;
using CityInformations.Domain.Entities;
using CityInformations.Infrastructure.Persistance;
using CityInformations.Shared.DTO;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace CityInformations.Tests.Integration.Features.Events
{
    public class Create : BaseSetUp, IDisposable
    {
        public MyDbContext DbContext { get; private set; }
        public Create()
        {
            DbContext = CreateNewDbContext();
        }

        [Fact]
        public async Task When_Id_Is_Higher_Than_Zero_Then_Throw_Exception()
        {
            // arrange
            IMapper mockMapper = GetMockMapper();

            var handler = new CreateHandler(DbContext, mockMapper);
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
        public async Task When_Event_Is_Null_Then_Throw_Exception()
        {
            IMapper mockMapper = GetMockMapper();

            var handler = new CreateHandler(DbContext, mockMapper);

            // act
            Func<Task> action = async () => await handler.Handle(new CreateCommand(null), CancellationToken.None);

            // asert
            await action.Should().ThrowAsync<ObjectIsNull>();
        }

        [Fact]
        public async Task When_Event_Is_Corrected_Then_Should_Add_Item_To_Database()
        {
            // arrange
            IMapper mockMapper = GetMockMapper();
            var handler = new CreateHandler(DbContext, mockMapper);
            EventDto eventDto = new EventDto()
            {
                Id = 0,
                Name = "Test mock",
            };

            var expectedEvent = new Event
            {
                Id = 0,
                Name = "Test mock",
            };

            mockMapper.Map<Event>(eventDto).Returns(expectedEvent);

            // act 
            await handler.Handle(new CreateCommand(eventDto), CancellationToken.None);

            List<Event> test = DbContext.Events.ToList();
            // assert
            var addedItem = await DbContext.Events.LastOrDefaultAsync();

            addedItem.Should().NotBeNull();

            addedItem.Should().BeEquivalentTo(expectedEvent, options => options.Excluding(x => x.Id));
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
