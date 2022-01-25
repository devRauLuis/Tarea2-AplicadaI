using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Tarea2
{
    public class Context : DbContext
    {

        public DbSet<Role> UserRoles { get; set; }
        protected override void OnConfiguring(
               DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=DATA/Roles.db");
        }
    }
}