using BoilerplateCleanArch.Domain.Entities;
using BoilerplateCleanArch.Infra.Data.EntitiesConfiguration.CategoryConfiguration;
using BoilerplateCleanArch.Infra.Data.EntitiesConfiguration.ProductConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BoilerplateCleanArch.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
