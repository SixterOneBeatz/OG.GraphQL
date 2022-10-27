using OG.GraphQL.API;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.ConfigureServices(configuration);

var app = builder.Build();

app.Configure();