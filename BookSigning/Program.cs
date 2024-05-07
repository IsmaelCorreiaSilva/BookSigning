using BookSigning.Routes;
using Infra.IoC.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI( options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = String.Empty;
});


app.MapBookRoutes();
app.MapSubscriptionTypeRoutes();
app.MapSubscriberRoutes();
app.MapMonthlyShippingRoutes();

app.Run();
