using Microsoft.EntityFrameworkCore;
using MINIBLOGAPI;

namespace MINIBLOGAPI
{
    
public class ApplicationDbContext : DbContext
{
    
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Comment> Comments {get;set;}

    public DbSet<Post> Posts {get;set;}
}

}