using Microsoft.EntityFrameworkCore;
using VideoMonitor.Context;
using VideoMonitor.Repository;
using VideoMonitor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IServerService, ServerService>();
builder.Services.AddTransient<IVideoService, VideoService>();
builder.Services.AddSingleton<IPingService, PingService>();
builder.Services.AddSingleton<IRecyclerService, RecyclerService>();

builder.Services.AddTransient<IServerRepository, ServerRepository>();
builder.Services.AddTransient<IVideoRepository, VideoRepository>();
builder.Services.AddSingleton<IVideoFileRepository, VideoFileRepository>();

builder.Services.AddScoped<VideoMonitorContext>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<VideoMonitorContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.Run();
