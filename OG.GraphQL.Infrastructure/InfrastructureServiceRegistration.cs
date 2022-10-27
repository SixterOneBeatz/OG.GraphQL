using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OG.GraphQL.Application.Common.Repositories;
using OG.GraphQL.Infrastructure.Contexts;
using OG.GraphQL.Infrastructure.Repositories;

namespace OG.GraphQL.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("GraphQLDataBase")), ServiceLifetime.Transient);
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
