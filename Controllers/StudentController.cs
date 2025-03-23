using DashboardBackend.Dtos.Student;
using DashboardBackend.Interfaces;
using DashboardBackend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace DashboardBackend.Controllers;
[Route("api/student")]
[ApiController]
public class StudentController(IStudentRepository studentRepository, IUserInformationFromToken userInformationFromToken) : ControllerBase
{
    private readonly IUserInformationFromToken _userInfo = userInformationFromToken;
    private readonly IStudentRepository _studentRepository = studentRepository;
    [HttpPost]
    [Route("vote")]
    public async Task<IActionResult> Vote(StudentVoteDto studentVoteDto)
    {
        var userInfo = await _userInfo.GetUserIdFromDatabase();
        if (userInfo == null)
        {
            throw new Exception("plz use token!");
        }
        var vote = studentVoteDto.ToVoteFormCreateDTO(userInfo.UserId ?? "");
        await _studentRepository.Vote(vote);
        return Ok("Voted");
    }

    [HttpGet]
    [Route("project_info")]
    public async Task<IActionResult> ProjectInfo()
    {
        var project = await _studentRepository.GetProjectDetailsByUserIdAsync();
        return Ok(project);
    }

    [HttpPut]
    [Route("{projectId:int}")]
    public async Task<IActionResult> ApproveStudents([FromRoute] int projectId)
    {
        var project = await _studentRepository.ApproveStudentsForProject(projectId);
        return Ok("approved");
    }
}
