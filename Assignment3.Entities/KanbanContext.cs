namespace Assignment3.Entities;

public class KanbanContext : DbContext
{
    public KanbanContext(){

    }
    
    public virtual DbSet<Task> Tasks => Set<Task>();
    public virtual DbSet<User> Users => Set<User>();
    public virtual DbSet<Tag> Tags => Set<Tag>();

}
