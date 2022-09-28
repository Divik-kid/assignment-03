namespace Assignment3.Entities;

public class KanbanContext : DbContext
{

    public virtual DbSet<Task> Tasks => Set<Task>();
    public virtual DbSet<User> Users => Set<User>();
    public virtual DbSet<Tag> Tags => Set<Tag>();
     public KanbanContext(DbContextOptions<KanbanContext> options): base(options)
    {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=assignment3db;Username=postgres;Password=abc");

        protected override void OnModelCreating(ModelBuilder modelBuilder){

        modelBuilder.Entity<Task>().Property(tsk => tsk.Title);
        
        modelBuilder.Entity<User>().Property(u => u.Name);
        modelBuilder.Entity<User>().Property(u => u.Email);
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
       
        modelBuilder.Entity<Tag>().Property(tg => tg.Name);
        modelBuilder.Entity<Tag>().HasIndex(tg => tg.Name).IsUnique();
    }
}
