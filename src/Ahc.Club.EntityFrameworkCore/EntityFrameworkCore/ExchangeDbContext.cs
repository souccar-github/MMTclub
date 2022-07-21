using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Ahc.Club.Authorization.Roles;
using Ahc.Club.Authorization.Users;
using Ahc.Club.MultiTenancy;
using Ahc.Club.Ahc.QrCodes;
using Ahc.Club.Ahc.Products;
using Ahc.Club.Ahc.Indexes;
using Ahc.Club.Ahc.Categories;
using Ahc.Club.Ahc.Gifts;
using Ahc.Club.Ahc.Levels;
using Ahc.Club.Ahc.Settings;

namespace Ahc.Club.EntityFrameworkCore
{
    public class ExchangeDbContext : AbpZeroDbContext<Tenant, Role, User, ExchangeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<QrCode> QrCodes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GeneralSetting> GeneralSettings { get; set; }
        public ExchangeDbContext(DbContextOptions<ExchangeDbContext> options)
            : base(options)
        {

        }

    }
}
