using System.Text.Json.Serialization;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddHttpLogging(o =>
{
    o.RequestHeaders.Add("X-Forwarded-For");
    o.RequestHeaders.Add("X-Real-IP");
    o.RequestHeaders.Add("sec-ch-ua");
    o.RequestHeaders.Add("sec-fetch-site");
    o.RequestHeaders.Add("sec-fetch-dest");
    o.RequestHeaders.Add("Referer");
    o.LoggingFields |= HttpLoggingFields.RequestBody;
    o.CombineLogs = true;
});

var app = builder.Build();
app.UseHttpLogging();
app.MapReverseProxy();
app.Run();
