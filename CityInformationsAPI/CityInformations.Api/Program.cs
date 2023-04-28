using CityInformations.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dodaj kontekst bazy danych do serwisu
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
var healthCareStatuses = new Dictionary<Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus, int>()
{
    { Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Healthy, 200 },
    { Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Degraded, 404 },
    { Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy, 500 }

};

app.MapHealthChecks("/healthz", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
{
    ResultStatusCodes = healthCareStatuses,
});

app.Run();
