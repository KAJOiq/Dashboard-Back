using projects.Dtos.Project;
using projects.Models;

namespace projects.Mappers;
public static class ProjectMapper
{

   public static GetProjectDto ToProjectDto(this Project projectModel)
    {
        return new GetProjectDto(
            projectModel.Id,
            projectModel.Title,
            projectModel.Description,
            projectModel.Pdf,
            projectModel.Supervisor_Id,
            projectModel.CreatedAt,
            projectModel.Deadline 
        );
    }

    public static Project ToProjectFormCreateDTO(this ProjectRequestDto projectRequestDto)
    {
        return new Project
        {
            Title = projectRequestDto.Title,
            Description = projectRequestDto.Description,
            Supervisor_Id = projectRequestDto.Supervisor_Id,
            Deadline = projectRequestDto.Deadline.ToUniversalTime(),
        };
    }
}
