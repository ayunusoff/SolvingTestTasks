using AltPoint.Api.Consumer.BuilderServices;
using AltPoint.Api.Consumer.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<RabbitListener>();

builder.Services.AddSingleton<ConsumerService>();
builder.Services.AddHostedService<ConsumerHostedService>();
var app = builder.Build();

// Configure the HTTP request pipeline.



app.Run();
