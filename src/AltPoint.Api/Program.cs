using AltPoint.Api.Handlers;
using AltPoint.Application;
using AltPoint.Infrastructure.Persistance.EFCore;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplication()
    .AddEfCorePersistance(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
