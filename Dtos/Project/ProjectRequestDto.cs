namespace projects.Dtos.Project;
public record ProjectRequestDto(
    string Title,
    string Description,
    string Supervisor_Id,
    DateTime Deadline
);
