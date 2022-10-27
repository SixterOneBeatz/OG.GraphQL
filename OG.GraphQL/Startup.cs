using Microsoft.Extensions.DependencyInjection;
using OG.GraphQL.API.GraphQL.Queries;
using OG.GraphQL.Application;
using OG.GraphQL.Infrastructure;

namespace OG.GraphQL.API
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddInfrastructure(configuration);
            services.AddApplication();
            services.AddGraphQLServer()
                .AddQueryType()
                .AddTypeExtension<CourseQuery>()
                .AddTypeExtension<PersonQuery>();
        }

        public static void Configure(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
               
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapGraphQL();

            app.Run();
        }
    }
}
