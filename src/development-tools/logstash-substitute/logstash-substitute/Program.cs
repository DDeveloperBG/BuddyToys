using logstash_substitute;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapPost("api/receive/log-info", ([FromBody] dynamic info) =>
{
    InMemoryStorage.AddInfo(info.ToString());
});

app.MapGet("show-log-info", () =>
{
    return InMemoryStorage.GetInfo();
});

app.Run();
