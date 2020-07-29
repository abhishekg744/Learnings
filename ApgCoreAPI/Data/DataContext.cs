using ApgCoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ApgCoreAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Character> Characters {get; set;}
        public DbSet<User> Users {get; set;}
        
    }
}