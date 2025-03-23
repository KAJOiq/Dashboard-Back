namespace DashboardBackend.Dtos.Student;
public class GetProjectInfoDto
{
    public int Id { set; get; }
    public bool? ApproveStatus { set; get; }
    public int ProjectId { set; get; }
    public string? StudentId { get; set; }
}
