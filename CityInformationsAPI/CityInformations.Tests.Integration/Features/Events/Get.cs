using AutoMapper;
using CityInformations.Application.Features.Events.Queries;
using FluentAssertions;

namespace CityInformations.Tests.Integration.Features.Events
{
    public class Get : BaseSetUp
    {
        [Fact]
        public async Task When_Table_Is_Empty_Then_Return_Empty_List()
        {
            // arrange
            IMapper mockMapper = GetMockMapper();
            var handler = new GetAllItemsHandler(DbContext, mockMapper);

            // act
            var result = await handler.Handle(new GetAllItemsQuery(), CancellationToken.None);
            var count = result.Count();
            //assert
            count.Should().Be(0);
        }
    }
}
