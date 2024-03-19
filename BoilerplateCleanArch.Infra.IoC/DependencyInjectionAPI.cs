using BoilerplateCleanArch.Application.Mappings;
using BoilerplateCleanArch.Domain.Account;
using BoilerplateCleanArch.Infra.Data.Context;
using BoilerplateCleanArch.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using BoilerplateCleanArch.Application.Interfaces.Email;
using BoilerplateCleanArch.Application.Services.Email;
using BoilerplateCleanArch.Application.DTOS.Email;
using BoilerplateCleanArch.Infra.Data.Repositories.CategoryRepository;
using BoilerplateCleanArch.Infra.Data.Repositories.ProductRepository;
using BoilerplateCleanArch.Domain.Interfaces.CategoryRepository;
using BoilerplateCleanArch.Domain.Interfaces.IProductRepository;
using BoilerplateCleanArch.Application.Interfaces.ICategoryService;
using BoilerplateCleanArch.Application.Interfaces.IProductService;
using BoilerplateCleanArch.Application.Services.CategoryService;
using BoilerplateCleanArch.Application.Services.ProductService;

namespace BoilerplateCleanArch.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();


            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddScoped<IEmailService, EmailService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));



            var myhandlers = AppDomain.CurrentDomain.Load("BoilerplateCleanArch.Application");
            //services.AddMediatR(myhandlers);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));


            //Configuração para Envio de e-mail
            var configuracaoSmtp = new ConfigurationDTO.SmtpConfiguracao();
            configuration.GetSection("Smtp").Bind(configuracaoSmtp);
            ConfigurationDTO.Smtp = configuracaoSmtp;


            return services;
        }
    }
}
