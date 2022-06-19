using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Ahc.Club.Configuration;
using Ahc.Club.Web;

namespace Ahc.Club.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ExchangeDbContextFactory : IDesignTimeDbContextFactory<ExchangeDbContext>
    {
        public ExchangeDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ExchangeDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ExchangeDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ExchangeConsts.ConnectionStringName));

            return new ExchangeDbContext(builder.Options);
        }
    }
}
