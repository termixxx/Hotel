using Hotel.Entities;
using Hotel.Repository;
using Hotel.WebAPI.AppConfiguration.ApplicationExtensions;
using Hotel.WebAPI.AppConfiguration.ServicesExtensions;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: false)
.Build();

builder.AddSerilogConfiguration();
builder.Services.AddVersioningConfiguration(); //add api versioning
builder.Services.AddDbContextConfiguration(configuration);
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration();

builder.Services.AddScoped<DbContext, HotelContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

app.UseSerilogConfiguration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Application starting...");

    app.Run();
}
catch (Exception ex)
{
    Log.Error("Application finished with error {error}", ex);
}
finally
{
    Log.Information("Application stopped");
    Log.CloseAndFlush();
}