namespace Assignment3.Entities;

public class User
{   
    public int Id {get;set;}
    
    [Required][MaxLength(100)]
    public String Name {get;set;} = "John Sekiro";

    [Required][MaxLength(100)]
    public String Email {get;set;} = "temp@Mail.com";
    
    public Task[] Tasks { get; set; } = new Task[0];

}
