using Microsoft.EntityFrameworkCore;
using WebAppDatabase.Models;
using WebAppDatabase.NewFolder1;

namespace WebAppDatabase.NewFolder
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
        }
       
    }
}
