using BoilerplateCleanArch.Application.Interfaces.ICategoryService;
using BoilerplateCleanArch.Application.Interfaces.IProductService;
using BoilerplateCleanArch.Application.Mappings;
using BoilerplateCleanArch.Application.Services.CategoryService;
using BoilerplateCleanArch.Application.Services.ProductService;
using BoilerplateCleanArch.Domain.Account;
using BoilerplateCleanArch.Domain.Interfaces.CategoryRepository;
using BoilerplateCleanArch.Domain.Interfaces.IProductRepository;
using BoilerplateCleanArch.Infra.Data.Context;
using BoilerplateCleanArch.Infra.Data.Identity;
using BoilerplateCleanArch.Infra.Data.Repositories.CategoryRepository;
using BoilerplateCleanArch.Infra.Data.Repositories.ProductRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BoilerplateCleanArch.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));



            var myhandlers = AppDomain.CurrentDomain.Load("BoilerplateCleanArch.Application");
            //services.AddMediatR(myhandlers);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));
            return services;
        }
    }
}
