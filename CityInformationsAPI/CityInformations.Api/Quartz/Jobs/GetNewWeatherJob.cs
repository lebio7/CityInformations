using CityInformations.Application.Helpers.Interfaces;
using Quartz;

namespace CityInformations.Api.Quartz.Jobs
{
    public class GetNewWeatherJob : IJob
    {
        private readonly IServiceProvider provider;

        public GetNewWeatherJob(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using var scope = provider.CreateScope();

            var weatherConditionService = scope.ServiceProvider.GetService<IWeatherCondition>();

            if (weatherConditionService != null)
            {
                var weather = await weatherConditionService.Get();
                if (weather != null)
                {
                    await weatherConditionService.Create(weather);
                }

            }
        }
    }
}
