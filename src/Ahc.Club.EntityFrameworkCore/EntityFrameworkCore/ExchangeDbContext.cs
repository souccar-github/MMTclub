using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Ahc.Club.Authorization.Roles;
using Ahc.Club.Authorization.Users;
using Ahc.Club.MultiTenancy;
using Ahc.Club.Ahc.QrCodes;
using Ahc.Club.Ahc.Products;
using Ahc.Club.Ahc.Indexes;
using Ahc.Club.Ahc.Categories;

namespace Ahc.Club.EntityFrameworkCore
{
    public class ExchangeDbContext : AbpZeroDbContext<Tenant, Role, User, ExchangeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<QrCode> QrCode { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductSize> ProductSize { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<Category> Category { get; set; }
        public ExchangeDbContext(DbContextOptions<ExchangeDbContext> options)
            : base(options)
        {

        }

    }
}
