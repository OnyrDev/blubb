using Microsoft.AspNetCore.HttpLogging;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts => opts.SwaggerDoc("v1", new OpenApiInfo
{
    Title = "Users API",
    Version = "v1"
}));
builder.Services.AddControllers();
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();

app.MapControllers();
app.UseHttpsRedirection();

app.Run();
