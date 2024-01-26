using Application.Interfaces;
using Application.Models.Book;
using Infra.IoC.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDependencyInjectionConfiguration();
var app = builder.Build();

app.MapGet("/v1/books", async (IBookService bookService) => {
    var books = await bookService.GetAll();
    return Results.Ok(books);
});
app.MapGet("/v1/books/{id}", async (IBookService bookService, int id) =>
{
    var book = await bookService.GetById(id);
    return Results.Ok(book);
});
app.MapPost("/v1/books", async (IBookService bookService, BookCreateModel createBook) =>
{
    var book = await bookService.Insert(createBook);

    return Results.Created($"/v1/books/{book}", book);
});
app.MapPut("/v1/books/", async (IBookService bookService, BookUpdateModel updateBook) =>
{
    var book = await bookService.GetById(updateBook.Id);

    if (book == null)
        return Results.BadRequest();

    await bookService.Update(updateBook);
    return Results.Ok();
});
app.MapDelete("/v1/books/{id}", async (IBookService bookService, int id) =>
{
    var result = await bookService.DeleteById(id);

    if (result == 1)
        return Results.NoContent();

    return Results.BadRequest();
});

app.Run();
