using DashboardBackend.Dtos.Student;
using DashboardBackend.Interfaces;
using Microsoft.EntityFrameworkCore;
using projects.Data;
using projects.Models;

namespace DashboardBackend.Repository;
public class StudentRepository(ApplicationDBContext context, IUserInformationFromToken userInformationFromToken) : IStudentRepository
{
    private readonly IUserInformationFromToken _userInformationFromToken = userInformationFromToken;
    private readonly ApplicationDBContext _context = context;

    public async Task<bool> ApproveStudentsForProject(int projectId)
    {
        var students = _context.Students.Where(t => t.ProjectId == projectId);
        if (!students.Any()) return false; 

        await students.ForEachAsync(student => student.ApproveStatus = true);

        await _context.SaveChangesAsync(); 

        return true;
    }

    public async Task<List<GetProjectInfoDto>> GetProjectDetailsByUserIdAsync()
    {
        var userInfo = await _userInformationFromToken.GetUserIdFromDatabase();

        var project = await _context.Students.Where(t => t.StudentId == userInfo.UserId).ToListAsync();
        if (project == null)
        {
            throw new NullReferenceException("Project not found.");
        }
        var projectInfoDto = project.Select(a => new GetProjectInfoDto
        {
            Id = a.Id,
            ApproveStatus = a.ApproveStatus,
            ProjectId = a.ProjectId,
            StudentId = a.StudentId
        });
        return projectInfoDto.ToList();
    }

    public async Task<Students> Vote(Students students)
    {
        await _context.Students.AddAsync(students);
        await _context.SaveChangesAsync();
        return students;
    }
}
