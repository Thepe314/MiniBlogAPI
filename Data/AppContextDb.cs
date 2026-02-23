using Microsoft.EntityFrameworkCore;
using MINIBLOGAPI;

namespace MINIBLOGAPI
{
    
public class AppDbContext : DbContext
{
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Comment> Comments {get;set;}

    public DbSet<Post> Posts {get;set;}
}

}