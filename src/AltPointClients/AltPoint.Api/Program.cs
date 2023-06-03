using AltPoint.Application;
using AltPoint.Infrastructure;
using AltPoint.Infrastructure.Persistance.EFCore;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplication()
    .AddEfCorePersistance(builder.Configuration);
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsProduction())
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AltPointContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
