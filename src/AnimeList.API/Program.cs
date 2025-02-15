using AnimeList.Application.Features.AnimesList.CreateList;
using AnimeList.Domain.Interface;
using AnimeList.Infrastructure.Data;
using AnimeList.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var loggerConfiguration = new LoggerConfiguration()
    .Enrich.WithClientIp()
    .Enrich.WithMachineName()
    .Enrich.WithCorrelationId()
    .Enrich.WithEnvironmentName()
    .Enrich.FromLogContext()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Is(builder.Environment.IsDevelopment() ?
        LogEventLevel.Debug :
        LogEventLevel.Information);

loggerConfiguration.WriteTo.Console(new JsonFormatter(renderMessage: true, formatProvider: new CultureInfo("en-US")));

Log.Logger = loggerConfiguration.CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger);
builder.Host.UseSerilog(Log.Logger);

// Variables
var connectionString = "Server=DESKTOP-IL6MI7E;Database=desafiodb;Integrated Security=SSPI;TrustServerCertificate=True";

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// cors
builder.Services.AddCors();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Injects
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSqlServer<AnimeDbContext>(connectionString, b => b.MigrationsAssembly("AnimeList.Api"));
builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
var assemblyApplication = AppDomain.CurrentDomain.Load("AnimeList.Application");
var assemblyInfrastructure = AppDomain.CurrentDomain.Load("AnimeList.Infrastructure");
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateListCommandHandler>());
builder.Services.AddAutoMapper(assemblyApplication, assemblyInfrastructure);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
            options.SwaggerEndpoint("/openapi/v1.json", "animes api"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
