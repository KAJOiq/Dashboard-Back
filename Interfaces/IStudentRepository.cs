using DashboardBackend.Dtos.Student;
using DashboardBackend.Repository;
using projects.Models;

namespace DashboardBackend.Interfaces;
public interface IStudentRepository
{
    Task<Students> Vote(Students students);
    Task<List<GetProjectInfoDto>> GetProjectDetailsByUserIdAsync();
    Task<bool> ApproveStudentsForProject(int projectId);
    Task<List<User>> GetAllStudentsByProjectId(int projectId);
}
