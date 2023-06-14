using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<WebApiContext>
    {
        public WebApiContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebApiContext>();
            optionsBuilder.UseNpgsql("Data Source=blog.db");

            return new WebApiContext(optionsBuilder.Options);
        }
    }
}
