using projects.Contracts;
using projects.Dtos.Project;
using projects.Models;

namespace projects.Interfaces;
public interface IProjectRepository
{

    Task<PaginatedResponse<Project>> GetAllAsync(ProjectQueryDto projectQueryDto);
    Task<Project> GetByIdAsync(int id);
    Task<Project> CreateAsync(Project projectModel);
    Task<Project> UpdateAsync(int id, ProjectRequestDto projectDto);
    Task<Project> UpdatePdfAsync(int id, string pdf);
    Task<Project> DeleteAsync(int id);
}
