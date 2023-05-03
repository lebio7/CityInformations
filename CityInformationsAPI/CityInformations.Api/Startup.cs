using CityInformations.Application.Features.Events.Queries;
using CityInformations.Infrastructure;
using MediatR;
using MediatR.Registration;
using System.Reflection;

namespace CityInformations.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var serviceConfig = new MediatRServiceConfiguration();
            ServiceRegistrar.AddRequiredServices(services, serviceConfig);
            services.AddHealthChecks();
            services.AddControllers();
            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(GetHandler).Assembly);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(CityInformations.Application.Helpers.MapperExtensions.MapperProfile));
            services.AddInfrastructure(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/healthz");
            });
        }
    }
}