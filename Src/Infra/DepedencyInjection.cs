using Application.Core.Interfaces;
using Application.Features.Product.Repositories;
using Infra.Data;
using Infra.Data.Repositories;
using Infra.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class DepedencyInjection
    {
        public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("app"));
            });

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Repositories
            services.AddTransient<IProductRepository, ProductRepository>();
        } 
    }
}
