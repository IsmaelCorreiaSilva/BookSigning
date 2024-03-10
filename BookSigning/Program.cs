using Application.Interfaces;
using Application.Interfaces.Book;
using Application.Interfaces.SubscriptionType;
using Application.Models.Book;
using Application.Models.SubscriptionType;
using Infra.IoC.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDependencyInjectionConfiguration();
var app = builder.Build();

app.MapGet("/v1/books", async (ISearchBookService bookService) => {
    var books = await bookService.GetAllAsync();
    return Results.Ok(books);
});
app.MapGet("/v1/books/{id}", async (ISearchBookService bookService, int id) =>
{
    var book = await bookService.GetByIdAsync(id);
    return Results.Ok(book);
});
app.MapPost("/v1/books", async (ICreateBookService bookService, BookCreateModel createBook) =>
{
    var book = await bookService.CreateBookAsync(createBook);

    return Results.Created($"/v1/books/{book}", book);
});
app.MapPut("/v1/books/", async (IUpdateBookService bookService, BookUpdateModel updateBook) =>
{
    await bookService.UpdateBookAsync(updateBook);
    return Results.Ok();
});
app.MapDelete("/v1/books/{id}", async (IDeleteBookService bookService, int id) =>
{
    var result = await bookService.DeleteByIdAsync(id);

    if (result == 1)
        return Results.NoContent();

    return Results.BadRequest();
});
app.MapPost("/v1/subscriptiontype", async (ICreateSubscriptionTypeService service, SubscriptionTypeCreateModel create) =>
{
    var result = await service.CreateSubscriptionTypeAsync(create);

    return Results.Created($"/v1/books/{result}", result);
});

app.Run();
