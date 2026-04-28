using BussNoLate.Api.Configuration;
using BussNoLate.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOptions<TrafiklabOptions>()
    .BindConfiguration(TrafiklabOptions.SectionName);

var app = builder.Build();

app.MapHealthEndpoints();

app.Run();
