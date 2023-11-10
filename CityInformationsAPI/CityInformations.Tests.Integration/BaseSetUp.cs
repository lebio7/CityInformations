using AutoMapper;
using CityInformations.Application.Helpers.MapperExtensions;
using CityInformations.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace CityInformations.Tests.Integration
{
    public class BaseSetUp : IDisposable
    {
        protected readonly MyDbContext DbContext;

        public BaseSetUp()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryTestDatabase").Options;
            DbContext = new MyDbContext(options);
        }

        public void Dispose()
        {
            DbContext.Dispose();
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
