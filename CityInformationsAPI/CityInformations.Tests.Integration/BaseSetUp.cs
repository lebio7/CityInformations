using AutoMapper;
using CityInformations.Api;
using CityInformations.Application.Helpers.MapperExtensions;
using CityInformations.Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace CityInformations.Tests.Integration
{
    public class BaseSetUp : IClassFixture<WebApplicationFactory<Startup>>
    {
        public readonly WebApplicationFactory<Startup> factory;

        /// <summary>
        /// To Mock dates
        /// </summary>
        public BaseSetUp() { }


        public BaseSetUp(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        public MyDbContext CreateNewDbContext()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new MyDbContext(options);
        }

        public IMapper GetMockMapper()
        {
            var mockMapper = Substitute.For<IMapper>();
            var configurationProvider = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MapperProfile());
            });
            mockMapper.ConfigurationProvider.Returns(configurationProvider);

            return mockMapper;
        }
    }
}
