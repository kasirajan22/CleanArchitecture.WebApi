namespace InfrastructureLayer;
using DomainLayer;
using Microsoft.EntityFrameworkCore;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public DbSet<User> Users { get; set; }

}