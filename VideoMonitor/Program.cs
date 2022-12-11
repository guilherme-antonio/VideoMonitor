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

builder.Services.AddScoped<IServerRepository, ServerRepository>();
builder.Services.AddScoped<IVideoRepository, VideoRepository>();

builder.Services.AddTransient<VideoMonitorContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
