using Microsoft.AspNetCore.Mvc;
using projects.Dtos.Project;
using projects.Interfaces;
using projects.Mappers;
using projects.Services;

namespace projects.Controllers;
[Route("api/project")]
[ApiController]
public class ProjectController(IProjectRepository projectRepository, IImageService imageService) : ControllerBase
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IImageService _imageService = imageService;
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ProjectQueryDto query)
    {
        var department = await _projectRepository.GetAllAsync(query);
        return Ok(department);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        return Ok(project.ToProjectDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProjectRequestDto projectRequestDto)
    {
        var departmentModel = projectRequestDto.ToProjectFormCreateDTO();
        await _projectRepository.CreateAsync(departmentModel);
        return CreatedAtAction(nameof(GetById), new { id = departmentModel.Id }, departmentModel.ToProjectDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromForm] ProjectRequestDto projectRequestDto)
    {
        var projectModel = await _projectRepository.UpdateAsync(id, projectRequestDto);
        return Ok(projectModel.ToProjectDto());
    }

    [HttpPut]
    [Route("updatepdf/{id}")]
    public async Task<IActionResult> UpdatePdf([FromRoute] int id, IFormFile pdf)
    {
        string? pdfPath = null;

        if (pdf != null)
        {
            pdfPath = await _imageService.UploadImageAsync(pdf);
        }
        var projectModel = await _projectRepository.UpdatePdfAsync(id, pdfPath);
        return Ok(projectModel.ToProjectDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _projectRepository.DeleteAsync(id);
        return Ok("deleted");
    }

}
