using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using projects.Data;

namespace projects.Database.Data;
public class ApplicationDBContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
{
    public ApplicationDBContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));

        return new ApplicationDBContext(optionsBuilder.Options);
    }
}
