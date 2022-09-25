namespace Assignment3.Entities;

public class Task
{
    public int Id {get;set;}
    
    [Required][MaxLength(100)]
    public String Title {get;set;} = "Unnamed Task";

    [MaxLength(int.MaxValue)]
    public string? Description {get;set;}

    public Tag[] Tags { get; set; } = new Tag[0];

    public User? AssignedTo { get; set; }
    
    public enum State {New,Active,Resolved,Closed,Removed}
}
