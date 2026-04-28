using BussNoLate.Api.Configuration;
using BussNoLate.Api.Endpoints;
using BussNoLate.Api.Integrations.Sl;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOptions<TrafiklabOptions>()
    .BindConfiguration(TrafiklabOptions.SectionName);

builder.Services.AddHttpClient<ISlTransportClient, SlTransportClient>(client =>
{
    client.BaseAddress = new Uri("https://transport.integration.sl.se/v1/");
});

var app = builder.Build();

app.MapHealthEndpoints();
app.MapSlDebugEndpoints();

app.Run();
