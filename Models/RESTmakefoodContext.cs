using Microsoft.EntityFrameworkCore;
 
namespace RESTmakefood.Models
{
    public class RESTmakefoodContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RESTmakefoodContext(DbContextOptions<RESTmakefoodContext> options) : base(options) { }
        
        public DbSet<Reviews> entries { get; set;}
    }
}
