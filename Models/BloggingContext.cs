using Microsoft.EntityFrameworkCore;
namespace EFTest.Models;
public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=EfTest;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}


