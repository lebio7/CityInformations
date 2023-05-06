using CityInformations.Api.Quartz.Jobs;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace CityInformations.Api.Quartz
{
    public class QuartzExtension
    {
        public static void QuartzInstallation(IServiceCollection services)
        {
            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddHostedService<QuartzHostedService>();

            services.AddSingleton<GetNewWeatherJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(GetNewWeatherJob),
                cronExpression: JobSchedule.CronExpressionEveryFiveMinutes));
        }
    }
}
