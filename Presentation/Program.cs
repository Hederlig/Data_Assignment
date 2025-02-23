using Business.Interface;
using Business.Services;
using Infrastructure.Contexts;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Presentation.Dialogs;
using Presentation.Dialogs.Interface;

namespace Presentation;

internal class Program
    {
    static async Task Main(string[] args)
        {
        var host = Host.CreateDefaultBuilder()
        .ConfigureServices(services =>
        {
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Skola\Datalagring\Data_Assignment\Infrastructure\Database\localdb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True")
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddFilter((category, level) =>
             category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information).AddConsole()))
             .EnableSensitiveDataLogging(false));

            services.AddScoped<IMainDialog, MainDialog>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IActivityStatusRepository, ActivityStatusRepository>();
            services.AddScoped<IActivityStatusService, ActivityStatusService>();
            services.AddScoped<IProjectService, ProjectService>();
        }).Build();

        using var scope = host.Services.CreateScope();
        var mainMenu = scope.ServiceProvider.GetRequiredService<IMainDialog>();

        // Lets get started !!!!
        await mainMenu.Run();
        }
    }

