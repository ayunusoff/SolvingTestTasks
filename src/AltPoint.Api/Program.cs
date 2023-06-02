using AltPoint.Application;
using AltPoint.Infrastructure.Persistance.EFCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplication()
    .AddEfCorePersistance(builder.Configuration);

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
