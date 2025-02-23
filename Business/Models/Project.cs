using Business.Models.Dtos;

namespace Business.Models;

public class Project
    {
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string ProjectManager { get; set; } = null!;
    public string Customer { get; set; } = null!;

    public int StatusId { get; set; }
    public StatusModel? Status { get; set; }
    }