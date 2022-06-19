using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Ahc.Club.EntityFrameworkCore
{
    public static class ExchangeDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ExchangeDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ExchangeDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
