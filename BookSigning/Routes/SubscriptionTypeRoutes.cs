using Application.Interfaces.SubscriptionType;
using Application.Models.SubscriptionType;

namespace BookSigning.Routes
{
    public static class SubscriptionTypeRoutes
    {
        public static void MapSubscriptionTypeRoutes(this WebApplication app)
        {
            app.MapPost("/v1/subscriptiontype", async (
                ICreateSubscriptionTypeService createSubscriptionTypeService, 
                SubscriptionTypeCreateModel createSubscriptionType) =>
            {
                var result = await createSubscriptionTypeService.CreateSubscriptionTypeAsync(createSubscriptionType);

                return Results.Created($"/v1/subscriptiontype/{result}", result);
            });
            app.MapPut("/v1/subscriptiontype", async (
                IUpdateSubscriptionTypeService updateSubscriptionTypeService,
                SubscriptionTypeUpdateModel updateSubscriptionType) =>
            {
                await updateSubscriptionTypeService.UpdateSubscriptionTypeAsync(updateSubscriptionType);

                return Results.Ok();
            });
            app.MapDelete("/v1/subscriptiontype/{id}", async (
                IDeleteSubscriptionTypeService deleteSubscriptionTypeService,
                int id) =>
            {
                var result = await deleteSubscriptionTypeService.DeleteByIdAsync(id);

                if(result == 1)
                    return Results.NoContent();

                return Results.BadRequest();
            });
        }
    }
}
