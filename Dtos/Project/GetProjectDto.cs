namespace projects.Dtos.Project;
public record GetProjectDto(
    int Id,
    string Title,
    string Description,
    string Pdf,
    string Supervisor_Id,
    DateTime CreatedAt,
    DateTime Deadline
);
