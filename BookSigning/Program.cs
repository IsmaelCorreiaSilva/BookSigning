using BookSigning.Data;
using BookSigning.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/v1/books", async () => {
    var bookData = new BookData();
    var books = await bookData.GetAll();
    return Results.Ok(books);
});
app.MapGet("/v1/books/{id}", async (int id) => {
    var bookData = new BookData();
    var book = await bookData.GetById(id);
    return Results.Ok(book);
});
app.MapPost("/v1/books", async (Book createBook) =>
{
    var bookData = new BookData();
    var book = await bookData.Insert(createBook);
    
    return Results.Created($"/v1/books/{book}", book);
});
app.MapPut("/v1/books/{id}", async (int id, Book updateBook) =>
{
    var bookData = new BookData();
    var book = await bookData.GetById(id);
    
    if(book == null)
        return Results.BadRequest();

    await bookData.Update(id, updateBook);
    return Results.Ok();
});
app.MapDelete("/v1/books/{id}", async (int id) =>
{
    var bookData = new BookData();
    var result = await bookData.DeleteById(id);
    
    if(result == 1)
        return Results.NoContent();

    return Results.BadRequest();
});

app.Run();
