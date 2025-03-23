using DashboardBackend.Dtos.Student;
using projects.Models;

namespace DashboardBackend.Mappers;
public static class StudentMapper
{
public static Students ToVoteFormCreateDTO(this StudentVoteDto studentVoteDto,string userId)
    {
        return new Students
        {
            StudentId = userId,
            ProjectId = studentVoteDto.ProjectId
        };
    }
}
