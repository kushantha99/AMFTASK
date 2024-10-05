using Microsoft.EntityFrameworkCore;
using TaskManagerTest.Models;

namespace TaskManagerTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserTask> UserTasks { get; set; } // Entity for your model
    }

}
