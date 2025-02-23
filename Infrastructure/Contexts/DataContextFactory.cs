using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
    public DataContext CreateDbContext(string[] args)
        {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Skola\\Datalagring\\Data_Assignment\\Infrastructure\\Database\\localdb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        return new DataContext(optionsBuilder.Options);
        }
    }

