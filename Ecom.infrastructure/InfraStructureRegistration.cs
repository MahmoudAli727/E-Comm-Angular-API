using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.infrastructure.Data;
using Ecom.infrastructure.Repositries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecom.infrastructure
{
    public static class InfraStructureRegistration
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IProductRepository,ProductRepository>();
            //services.AddScoped<IPhotoRepository,PhotoRepository>();

            // Add UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add DbContext
            services.AddDbContext<AppDbContext>(op =>
                        op.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
          
            return services;
        }
    }
}
