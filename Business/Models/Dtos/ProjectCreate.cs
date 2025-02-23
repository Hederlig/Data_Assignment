namespace Business.Models.Dtos;

public class ProjectCreate
    {
    public string ProjectName { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Manager { get; set; } = null!;
    public int StatusId { get; set; }
    public string Customer { get; set; } = null!;
    }
