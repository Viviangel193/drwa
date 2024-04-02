using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<TodoItem> Guru { get; set; } // Perubahan nama dari 'guru' menjadi 'Guru'
    }

    public class ApplicationDbContextt : DbContext
    {
        public ApplicationDbContextt(DbContextOptions<ApplicationDbContextt> options) : base(options)
        {
        }
        public DbSet<TodoItem> Mapel { get; set; }
    } 
}
