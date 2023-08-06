using developChallenge.Domain.Interfaces.Repository;
using developChallenge.Domain.Interfaces.Services;
using developChallenge.Infra.Context;
using developChallenge.Infra.Repository;
using developChallenge.Service;
using developChallenge.Web.Api;
using Microsoft.EntityFrameworkCore;

System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//SQL Server
//builder.Services.AddDbContext<MyDatabaseContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);

builder.Services.AddDbContext<MyDatabaseContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
}, ServiceLifetime.Transient);

// Register the implementation of IAirportServices
builder.Services.AddScoped<IAirportServices, AirportServices>();

builder.Services.AddScoped<IAirportInfoRepository, AirportInfoRepository>();
builder.Services.AddScoped<ILoggerRepository, LoggerRepository>();
// Add HttpClient
builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
