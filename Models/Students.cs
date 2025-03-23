using System.Text.Json.Serialization;

namespace projects.Models;
public class Students
{
    public int Id {set; get;}
    public bool ApproveStatus {set; get;} = false;
    public int ProjectId { set; get; }
    [JsonIgnore]
    public Project Project {set; get;} = null!;
    public string StudentId { get; set; } = string.Empty;
    public User? Student { set; get; } = null!;
}
