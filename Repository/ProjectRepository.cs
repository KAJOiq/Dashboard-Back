using Microsoft.EntityFrameworkCore;
using projects.Contracts;
using projects.Data;
using projects.Dtos.Project;
using projects.Interfaces;
using projects.Models;

namespace projects.Repository;
public class ProjectRepository(ApplicationDBContext context) : IProjectRepository
{
    private readonly ApplicationDBContext _context = context;
    public async Task<Project> CreateAsync(Project projectModel)
    {
        await _context.Project.AddAsync(projectModel);
        await _context.SaveChangesAsync();
        return projectModel;
    }

    public async Task<Project> DeleteAsync(int id)
    {
        var projectModel = await _context.Project.FirstOrDefaultAsync(x => x.Id == id);
        if (projectModel == null)
        {
            throw new KeyNotFoundException($"Project ID {id} not found.");
        }
        _context.Project.Remove(projectModel);
        await _context.SaveChangesAsync();
        return projectModel;
    }

    public async Task<PaginatedResponse<Project>> GetAllAsync(ProjectQueryDto projectQueryDto)
    {
        IQueryable<Project> query = _context.Project.Include(p => p.Students);

        return await PaginatedResponse<Project>.CreateAsync(query, projectQueryDto.CurrentPage, projectQueryDto.PageSize);
    }

    public async Task<Project> GetByIdAsync(int id)
    {
        var project = await _context.Project.FirstOrDefaultAsync(i => i.Id == id);
        if (project == null)
        {
            throw new KeyNotFoundException($"Project ID {id} not found.");
        }
        return project;
    }

    public async Task<Project> UpdateAsync(int id, ProjectRequestDto projectDto)
    {
        var existingProject = await _context.Project.FirstOrDefaultAsync(x => x.Id == id);
        if (existingProject == null)
        {
            throw new KeyNotFoundException($"Project ID {id} not found.");
        }
        existingProject.Title = projectDto.Title;
        existingProject.Description = projectDto.Description;
        existingProject.Deadline = projectDto.Deadline;
        existingProject.Supervisor_Id = projectDto.Supervisor_Id;

        await _context.SaveChangesAsync();
        return existingProject;
    }

    public async Task<Project> UpdatePdfAsync(int id, string pdf)
    {
        var existingProject = await _context.Project.FirstOrDefaultAsync(x => x.Id == id);
        if (existingProject == null)
        {
            throw new KeyNotFoundException($"Project ID {id} not found.");
        }
        existingProject.Pdf = pdf;

        await _context.SaveChangesAsync();
        return existingProject;
    }
}
