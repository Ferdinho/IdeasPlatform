using Microsoft.EntityFrameworkCore;
 
namespace FinalExams.Models
{
    public class MyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<User> users {get;set;}
        public DbSet<Idea> ideas {get;set;}

        public DbSet<Association> associations {get;set;}

    }
}
