namespace projects.Models;
public class Project
{
    public int Id { set; get; } 
    public string Title { set; get; } = string.Empty;
    public string Description { set; get; } = string.Empty;
    public string Pdf { set; get; } = string.Empty;
    public string Supervisor_Id { set; get; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime Deadline { get; set; }  = DateTime.UtcNow;
    public List<Students> Students {set; get;} = [];
}
