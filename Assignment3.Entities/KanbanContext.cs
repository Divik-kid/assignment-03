namespace Assignment3.Entities;

public class KanbanContext : DbContext
{
    public KanbanContext(DbContextOptions<KanbanContext> options): base(options)
    {}
    public virtual DbSet<Task> Tasks => Set<Task>();
    public virtual DbSet<User> Users => Set<User>();
    public virtual DbSet<Tag> Tags => Set<Tag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder){

        modelBuilder.Entity<Task>().Property(tsk => tsk.Title);
        
        modelBuilder.Entity<User>().Property(u => u.Name);
        modelBuilder.Entity<User>().Property(u => u.Email);
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
       
        modelBuilder.Entity<Tag>().Property(tg => tg.Name);
        modelBuilder.Entity<Tag>().HasIndex(tg => tg.Name).IsUnique();
    }
}
