
using Business.Factories;
using Business.Interface;
using Business.Models.Dtos;
using Infrastructure.Interfaces;

namespace Business.Services;

public class ActivityStatusService(IActivityStatusRepository activityStatusRepository) : IActivityStatusService
    {
    private readonly IActivityStatusRepository _activityStatusRepository = activityStatusRepository;

    //public async Task<bool> CreateNewStatusAsync(ActivityStatusCreate form)
    //    {

    //    if (!await _activityStatusRepository.ExistsAsync(x => x.Status == form.Status))
    //        {
    //        var entity = ActivityStatusFactory.Create(form);
    //        entity = await _activityStatusRepository.GetAsync(entity);
    //        return true;
    //        }
    //    return false;
    //    }
    //}

    public async Task<IEnumerable<ActivityStatus>> GetActivityStatusesAsync()
        {
        var entities = await _activityStatusRepository.GetAllAsync();
        var models = entities.Select(ActivityStatusFactory.Create).ToList();
        return models;
        }

    }
