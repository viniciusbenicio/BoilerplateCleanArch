using BoilerplateCleanArch.Domain.Entities;
using BoilerplateCleanArch.Infra.Data.EntitiesConfiguration.UserConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BoilerplateCleanArch.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
