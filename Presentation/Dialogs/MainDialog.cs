using Business.Interface;
using Business.Models;
using Business.Models.Dtos;
using Presentation.Dialogs.Interface;

namespace Presentation.Dialogs;

public class MainDialog(IProjectService projectService) : IMainDialog
    {
    private readonly IProjectService _projectService = projectService;

    public async Task Run()
        {
        while (true)
            {
            await ListProjects();
            var input = Console.ReadKey();

            switch (input.KeyChar)
                {
                case '1':
                        {
                        await AddProject();
                        break;
                        }
                case '2':
                        {
                        await EditProject();
                        break;
                        }
                case '3':
                        {
                        await RemoveProject();
                        break;
                        }
                default:
                        {
                        break;
                        }
                }
            }
        }

    public async Task ListProjects()
        {
        // Get data from DB
        var DataFromDataBase = await _projectService.GetAllAsync();
        Console.Clear();
        Console.WriteLine("\n######## PROJECT LIST ##############");

        // Print main list
        foreach (Project project in DataFromDataBase)
            {

            Console.WriteLine($"\n-[{project.Id}]");
            Console.WriteLine($" {project.ProjectName}");
            Console.WriteLine($" {project.Status!.Status}");
            Console.WriteLine($" {project.ProjectManager}");
            Console.WriteLine($" {project.Customer}");
            Console.WriteLine($" {project.StartDate}");
            Console.WriteLine($" {project.EndDate}");
            }

        Console.WriteLine("\n------------------------------------");
        Console.WriteLine("-- [1]-Add  [2]-Edit  [3]-Remove --");
        }

    public async Task AddProject()
        {
        Console.Clear();
        Console.WriteLine("\n######## ADD PROJECT ##############");

        var form = new ProjectCreate();
        Console.Write("Project name: ");
        form.ProjectName = Console.ReadLine()!;
        Console.Write("Status: (1 = Not Started, 2 = In Progres, 3 = Completed ");
        form.StatusId = int.Parse(Console.ReadLine()!);
        Console.Write("ProjectManager: ");
        form.Manager = Console.ReadLine()!;
        Console.Write("Customer: ");
        form.Customer = Console.ReadLine()!;
        Console.Write("StartDate: ");
        form.StartDate = DateTime.Parse(Console.ReadLine()!);
        Console.Write("EndDate: ");
        form.EndDate = DateTime.Parse(Console.ReadLine()!);
        await _projectService.AddAsync(form);
        }

    public async Task RemoveProject()
        {

        Console.Write("\nWhat project to you want to remove?  ");
        var id = int.Parse(Console.ReadLine()!);
        await _projectService.RemoveAsync(id);
        }

    public async Task EditProject()
        {

        Console.Write("\nWhat project to you want to edit?  ");
        var id = int.Parse(Console.ReadLine()!);
        var project = await _projectService.GetByIdAsync(id);

        Console.Clear();
        Console.Write("New Project name: ");
        project.ProjectName = Console.ReadLine()!;

        Console.Write("New Status: (1 = Not Started, 2 = In Progres, 3 = Completed ");
        project.StatusId = int.Parse(Console.ReadLine()!);

        Console.Write("New ProjectManager: ");
        project.ProjectManager = Console.ReadLine()!;

        Console.Write("New Customer: ");
        project.Customer = Console.ReadLine()!;

        Console.Write("New StartDate: ");
        project.StartDate = DateTime.Parse(Console.ReadLine()!);

        Console.Write("New EndDate: ");
        project.EndDate = DateTime.Parse(Console.ReadLine()!);

        await _projectService.UpdateAsync(project);

        }
    }


