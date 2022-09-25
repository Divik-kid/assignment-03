namespace Assignment3.Entities;

public class Tag
{
    public int Id{get;set;}
    
    [Required][MaxLength(50)]
    public string Name {get;set;} = "Temp_tag";

    public Task[] Tasks { get; set; } = new Task[0];

}
