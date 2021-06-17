using EmployeeService.Domain.Interfaces;
using EmployeeService.Infrastructure.Configuration;
using EmployeeService.Infrastructure.Data.Persistance;
using EmployeeService.Infrastructure.Data.Repositories;
using EmployeeService.Infrastructure.Mail;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {                       
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));                        
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddDbContext<EmployeeDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlConeection")));

             services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
              services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
