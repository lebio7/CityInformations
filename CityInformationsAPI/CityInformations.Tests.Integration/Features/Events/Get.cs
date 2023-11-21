using AutoMapper;
using CityInformations.Api;
using CityInformations.Application.Features.Events.Queries;
using CityInformations.Infrastructure.Persistance;
using CityInformations.Shared.DTO;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace CityInformations.Tests.Integration.Features.Events
{
    public class Get : BaseSetUp
    {
        public MyDbContext DbContext { get; private set; }
        public Get(WebApplicationFactory<Startup> factory)
            : base(factory)
        {
            DbContext = CreateNewDbContext();
        }

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

        /// <summary>
        /// Event table has const values
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task When_Table_Has_Record_By_Id_Get_This_Record()
        {
            // arrange
            var client = factory.CreateClient();

            // act
            var response = await client.GetAsync("/restapi/Event/Get/1");

            //assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            content.Should().NotBeNull();
            content.Should().NotBeEmpty();
            var result = JsonConvert.DeserializeObject<EventDto>(content);
            result?.Should().NotBeNull();
            result?.Id.Should().Be(result.Id);
        }
    }
}
