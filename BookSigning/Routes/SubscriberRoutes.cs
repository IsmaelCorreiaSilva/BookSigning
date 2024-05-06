using Application.Interfaces.Subscriber;
using Application.Models.Subscriber;

namespace BookSigning.Routes
{
    public static class SubscriberRoutes
    {
        public static void MapSubscriberRoutes(this WebApplication app)
        {
            app.MapPost("/v1/subscriber", async(
                ICreateSubscriberService createSubscriberService, 
                SubscriberCreateModel createSubscriber) =>
            {
                var result = await createSubscriberService.CreateSubscriberAsync(createSubscriber);
                return Results.Created($"/v1/subscriber/{result}", result);
            });
            app.MapPut("/v1/subscriber", async (
                IUpdateSubscriberService updateSubscriberService,
                SubscriberUpdateModel upateSubscriber) =>
            {
                await updateSubscriberService.UpdateSubscriberAsync(upateSubscriber);
                return Results.Ok();
            });
            app.MapDelete("/v1/subscriber", async (
                IDeleteSubscriberService deleteSubscriberService,
                int id) =>
            {
                var result = await deleteSubscriberService.DeleteByIdAsync(id);

                if(result == 0)
                    return Results.NoContent();

                return Results.BadRequest();
            });
            app.MapGet("/v1/subscriber", async (
                ISearchSubscriberService searchSubscriberService) =>
            {
                return await searchSubscriberService.GetAllAsync();
            });
            app.MapGet("/v1/subscriber/{id}", async (
                ISearchSubscriberService searchSubscriberService,
                int id) =>
            {
                return await  searchSubscriberService.GetByIdAsync(id);
            });
        }
    }
}
