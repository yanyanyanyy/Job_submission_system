using Microsoft.EntityFrameworkCore;
namespace webapi.Data
{
    public class LogInContext:DbContext
    {
        public LogInContext(DbContextOptions<LogInContext> options) : base(options) { }
        public DbSet<Models.User> user { get; set; }
    }
}
