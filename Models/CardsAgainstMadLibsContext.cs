using Microsoft.EntityFrameworkCore;

namespace CardsAgainstMadLibs.Models
{
    public class CardsAgainstMadLibsContext : DbContext
    {
        public CardsAgainstMadLibsContext(DbContextOptions options) : base(options){}
        public DbSet<User>Users{get;set;}
        public DbSet<Card>Cards{get;set;}

    }
}