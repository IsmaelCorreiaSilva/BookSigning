using Application.Interfaces.MonthlyShipping;
using Application.Models.MonthlyShipping;
using Core.Entities;

namespace BookSigning.Routes
{
    public static class MonthlyShippingRoutes
    {
        public static void MapMonthlyShippingRoutes(this WebApplication app)
        {
            app.MapPost("/v1/monthlyshipping", async (
                ICreateMonthlyShippingService createMonthlyShippingService, 
                MonthlyShippingCreateModel createMonthlyShipping) => { 
                
                    var result = await createMonthlyShippingService.CreateMonthlyShippingAsync(createMonthlyShipping);
                
                    return Results.Created($"/v1/monthlyshipping/{result}", result);
            });

            app.MapPut("/v1/monthlyshipping", async (
                IUpdateMonthlyShippingService updateMonthlyShippingService,
                MonthlyShippingUpdateModel updateMonthlyShipping) => {
                    
                    await updateMonthlyShippingService.UpdateMonthlyShippingAsync(updateMonthlyShipping);
                    return Results.Ok();
            });

            app.MapDelete("/v1/monthlyshipping/{int}", async (
                IDeleteMonthlyShippingService deleteMonthlyShippingService, int id) => {

                    var result = await deleteMonthlyShippingService.DeleteByIdAsync(id);

                    if (result == 1)
                        return Results.NoContent();

                    return Results.BadRequest();
            });
        }
    }
}
