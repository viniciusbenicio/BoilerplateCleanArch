using BoilerplateCleanArch.Application.DTOS.Email;
using BoilerplateCleanArch.Application.Interfaces.Email;
using BoilerplateCleanArch.Application.Interfaces.ICategoryService;
using BoilerplateCleanArch.Application.Interfaces.IProductService;
using BoilerplateCleanArch.Application.Mappings;
using BoilerplateCleanArch.Application.Services.CategoryService;
using BoilerplateCleanArch.Application.Services.Email;
using BoilerplateCleanArch.Application.Services.ProductService;
using BoilerplateCleanArch.Domain.Interfaces.CategoryRepository;
using BoilerplateCleanArch.Domain.Interfaces.IProductRepository;
using BoilerplateCleanArch.Domain.Interfaces.IUserRepository;
using BoilerplateCleanArch.Infra.Data.Context;
using BoilerplateCleanArch.Infra.Data.Repositories.CategoryRepository;
using BoilerplateCleanArch.Infra.Data.Repositories.ProductRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BoilerplateCleanArch.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
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
