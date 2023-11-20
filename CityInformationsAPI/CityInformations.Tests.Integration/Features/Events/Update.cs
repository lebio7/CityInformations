using AutoMapper;
using CityInformations.Application.Exceptions;
using CityInformations.Application.Features.Events.Commands;
using CityInformations.Domain.Entities;
using CityInformations.Domain.Exceptions;
using CityInformations.Infrastructure.Persistance;
using CityInformations.Shared.DTO;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace CityInformations.Tests.Integration.Features.Events
{
    public class Update : BaseSetUp, IDisposable
    {
        public MyDbContext DbContext { get; private set; }
        public Update()
        {
            DbContext = CreateNewDbContext();
        }

        [Fact]
        public async Task When_Id_Is_Null_Or_Zero_Than_Throw_Exception()
        {
            var handler = new UpdateHandler(DbContext, null);
            EventDto eventDto = new EventDto()
            {
                Id = 0,
            };

            // act
            Func<Task> action = async () => await handler.Handle(new UpdateCommand(eventDto), CancellationToken.None);

            // asert
            await action.Should().ThrowAsync<GivenIdEqualsZero>();
        }

        [Fact]
        public async Task When_Id_Is_Not_Exist_Than_Throw_Not_Found_Exception()
        {
            var lastItem = await DbContext.Events.LastOrDefaultAsync();
            var handler = new UpdateHandler(DbContext, null);
            EventDto eventDto = new EventDto()
            {
                Id = lastItem?.Id ?? 1,
            };

            // act
            Func<Task> action = async () => await handler.Handle(new UpdateCommand(eventDto), CancellationToken.None);

            // asert
            await action.Should().ThrowAsync<NotFoundException>();
        }

        [Fact]
        public async Task When_Id_Is_Exist_Than_Should_Update_Item_To_Database()
        {
            // arrange
            IMapper mockMapper = GetMockMapper();
            var handler = new UpdateHandler(DbContext, mockMapper);
            string testName = "Test23";
            EventDto eventDto = new EventDto()
            {
                Id = 1,
                Name = testName,
            };

            var expectedEvent = new Event
            {
                Id = 1,
                Name = "Test mock",
            };

            DbContext.Events.Add(expectedEvent);
            DbContext.SaveChanges();

            expectedEvent.Name = testName;
            mockMapper.Map(eventDto, expectedEvent).Returns(expectedEvent);

            // act 
            await handler.Handle(new UpdateCommand(eventDto), CancellationToken.None);

            Event? entity = DbContext.Events.FirstOrDefault(x => x.Id == expectedEvent.Id);

            entity?.Should().NotBeNull();
            entity?.Name.Should().BeSameAs(testName);
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
