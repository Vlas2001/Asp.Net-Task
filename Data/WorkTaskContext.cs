using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Data
{
    public class WorkTaskContext: DbContext
    {
        public DbSet<Person> Users { get; set; }
        
        public WorkTaskContext(DbContextOptions<WorkTaskContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}