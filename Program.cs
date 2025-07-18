
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var blogs = new List<Blog>
{
    new Blog {Title = "My firts Post", Body = "This is my firts post" },
    new Blog {Title = "My second Post", Body = "This is my second post"}
};


app.MapGet("/", () => "I am root!");

app.MapGet("/blogs", () =>
{
    return blogs;
});

app.MapGet("/blogs/{id}", (int id) =>
{
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }
    else
    {
        return Results.Ok(blogs[id]);
    }

});

app.MapPost("/blogs", (Blog blog) =>
{
    blogs.Add(blog);
    return Results.Created($"/blogs/{blogs.Count - 1}", blog);
});

app.MapDelete("/blogs/{id}", (int id) =>
{
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }
    else
    {
        //var blog = blogs[id];
        blogs.RemoveAt(id);
        return Results.NoContent();
    }

});

app.MapPut("/blogs/{id}", (int id, Blog blog) =>
{
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }
    else
    {
        blogs[id] = blog;
        return Results.Ok(blog);
    }

});


app.Run();


public class Blog
{
    public required string Title { get; set; }
    public required string Body { get; set; }
}
