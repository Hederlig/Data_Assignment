
using System.ComponentModel.DataAnnotations.Schema;
using Business.Models;
using Business.Models.Dtos;
using Infrastructure.Entities;

namespace Business.Factories;

public static class ProjectFactory
    {
    public static ProjectEntity Create(ProjectCreate form) => new()
        {
        ProjectName = form.ProjectName,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        ProjectManager = form.Manager,
        StatusId = form.StatusId,
        Customer = form.Customer
        };

    public static ProjectEntity Update(ProjectUpdate form) => new()
        {
        Id = form.Id,
        ProjectName = form.ProjectName,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        ProjectManager = form.Manager,
        StatusId = form.StatusId,
        Customer = form.Customer
        };

    public static Project Create(ProjectEntity entity) => new()
        {
        Id = entity.Id,
        ProjectName = entity.ProjectName,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        ProjectManager = entity.ProjectManager,
        Customer = entity.Customer,
        StatusId = entity.StatusId,
   
        };
    }
