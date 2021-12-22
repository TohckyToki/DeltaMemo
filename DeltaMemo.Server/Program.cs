using Microsoft.EntityFrameworkCore;
using DeltaMemo.Server;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DeltaMemoContext>(opt => opt.UseMySql(builder.Configuration["DeltaMemo:DbConnection"], Microsoft.EntityFrameworkCore.ServerVersion.Parse(builder.Configuration["DeltaMemo:DbVersion"])));

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/Contents", async (DeltaMemoContext db) => await db.Contents.ToListAsync());

app.MapGet("/Contents/{id}", async (int id, DeltaMemoContext db) =>
    await db.Contents.FindAsync(id)
        is Content content
            ? Results.Ok(content)
            : Results.NotFound());

app.MapPost("/Contents", async (Content content, DeltaMemoContext db) =>
{
    db.Contents.Add(content);
    await db.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/Contents/{id}", async (int id, Content inputContent, DeltaMemoContext db) =>
{
    var content = await db.Contents.FindAsync(id);

    if (content is null) return Results.NotFound();

    content.WroteText = inputContent.WroteText;

    await db.SaveChangesAsync();

    return Results.Ok();
});

app.MapDelete("/Contents/{id}", async (int id, DeltaMemoContext db) =>
{
    if (await db.Contents.FindAsync(id) is Content content)
    {
        db.Contents.Remove(content);
        await db.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.Run();
