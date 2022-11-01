using OG.GraphQL.API.GraphQL.Mutations;
using OG.GraphQL.API.GraphQL.Queries;
using OG.GraphQL.API.GraphQL.Subscriptions;
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
            services.AddInMemorySubscriptions();
            services.AddGraphQLServer()
                .AddQueryType()
                .AddTypeExtension<CourseQuery>()
                .AddTypeExtension<PersonQuery>()
                .AddMutationType()
                .AddTypeExtension<PersonMutation>()
                .AddSubscriptionType()
                .AddTypeExtension<PersonSubscription>();
        }

        public static void Configure(this WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseWebSockets();

            app.MapControllers();

            app.MapGraphQL();

            app.Run();
        }
    }
}
