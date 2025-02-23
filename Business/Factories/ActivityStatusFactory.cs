using Business.Models.Dtos;
using Infrastructure.Entities;

namespace Business.Factories;

public static class ActivityStatusFactory
    {
    public static ActivityStatusEntity Create(ActivityStatusCreate form) => new()
        {
        Status = form.Status
        };
    public static ActivityStatusEntity Update(ActivityStatusUpdate form) => new()
        {
        Id = form.Id,
        Status = form.Status
        };

    public static ActivityStatus Create(ActivityStatusEntity entity) => new(entity.Id, entity.Status);
    }


