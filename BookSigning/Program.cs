using BookSigning.Routes;
using Infra.IoC.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDependencyInjectionConfiguration();
var app = builder.Build();


app.MapBookRoutes();
app.MapSubscriptionTypeRoutes();

app.Run();
