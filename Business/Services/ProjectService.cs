using Business.Interface;
using Business.Models;
using Business.Models.Dtos;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
    {
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<IEnumerable<Project>> GetAllAsync()
        {
        // Get all projects from the database
        var entities = await _projectRepository.GetAllAsync();

        // Map the entities to the models and return them
        return entities.Select(e => new Project
            {
            Id = e.Id,
            ProjectName = e.ProjectName,
            StartDate = e.StartDate,
            EndDate = e.EndDate,
            ProjectManager = e.ProjectManager,
            Customer = e.Customer,
            StatusId = e.StatusId,
            Status = new StatusModel { Status = e.Status.Status },
            });
        }

    public async Task<Project> GetByIdAsync(int id)
        {
        // Get the project from the database
        var entity = await _projectRepository.GetAsync(i => i.Id == id);

        // Map the entity to the model and return it
        return new Project
            {
            Id = entity!.Id,
            ProjectName = entity.ProjectName,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            ProjectManager = entity.ProjectManager,
            Customer = entity.Customer,
            Status = new StatusModel { Status = entity.Status.Status }
            };
        }


    public async Task AddAsync(ProjectCreate registrationForm)
        {
        // Remap the model to the entity
        var entity = new ProjectEntity
            {
            ProjectName = registrationForm.ProjectName,
            StartDate = registrationForm.StartDate,
            EndDate = registrationForm.EndDate,
            ProjectManager = registrationForm.Manager,
            Customer = registrationForm.Customer,
            StatusId = registrationForm.StatusId
            };

        // Add the entity to the database
        await _projectRepository.AddAsync(entity);
        }
    public async Task UpdateAsync(Project project)
        {
        // Get the project from the database
        var entity = await _projectRepository.GetAsync(i => i.Id == project.Id);
        // Update the entity with the new values
        entity!.ProjectName = project.ProjectName;
        entity.StartDate = project.StartDate;
        entity.EndDate = project.EndDate;
        entity.ProjectManager = project.ProjectManager;
        entity.Customer = project.Customer;
        entity.StatusId = project.StatusId;
        // Update the entity in the database
        await _projectRepository.UpdateAsync(entity);
        
        }

    public async Task RemoveAsync(int id)
        {
        // Get the project from the database
        var entity = await _projectRepository.GetAsync(i => i.Id == id);
        await _projectRepository.RemoveAsync(entity!);
        }
    }

