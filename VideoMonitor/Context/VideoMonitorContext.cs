using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using VideoMonitor.Models;

namespace VideoMonitor.Context
{
    public class VideoMonitorContext : DbContext
    {
        private readonly PostgreSQLConfig _postgreSQLConfig;
        public DbSet<Server> Servers { get; set; }
        public DbSet<Video> Videos => Set<Video>();

        public VideoMonitorContext(IConfiguration configuration)
        {
            _postgreSQLConfig = new PostgreSQLConfig();
            configuration.GetSection(PostgreSQLConfig.Config).Bind(_postgreSQLConfig);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql(@$"Host={_postgreSQLConfig.Host};Username={_postgreSQLConfig.Username};
                                    Password={_postgreSQLConfig.Password};Database={_postgreSQLConfig.Database}");
    }
}
