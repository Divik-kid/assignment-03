namespace Assignment3.Entities;

public class KanbanContext : DbContext
{

    public virtual DbSet<Task> Tasks => Set<Task>();
    public virtual DbSet<User> Users => Set<User>();
    public virtual DbSet<Tag> Tags => Set<Tag>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=assignment3db;Username=postgres;Password=abc");
}
