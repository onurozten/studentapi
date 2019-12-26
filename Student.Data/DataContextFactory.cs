using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Student.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-IDP3QB3\\SQLEXPRESS;Initial Catalog=StudentDB;integrated security=true");
            return new DataContext(optionsBuilder.Options);
            //return new DataContext("Data Source=DESKTOP-IDP3QB3\\SQLEXPRESS;Initial Catalog=StudentDB;integrated security=true");
        }
    }
}
