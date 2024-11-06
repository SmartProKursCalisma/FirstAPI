using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Dao
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=202-00;database=CourseProjectDb;User Id=sa;Password=1234;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Student> Students{ get; set; }
    }
}
