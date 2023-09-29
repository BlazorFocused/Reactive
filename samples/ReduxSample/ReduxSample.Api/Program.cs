// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReduxSample.Api;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DbConnection")));

string allowedSpecification = "_AllowedPolicySpecificationCORS";

builder.Services.AddCors(options =>
{
    options.AddPolicy(allowedSpecification, builder =>
    {
        builder.WithOrigins("https://localhost:7191");
        builder.WithMethods("GET", "POST", "PUT");
        builder.AllowAnyHeader();
    });
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(allowedSpecification);

    using IServiceScope scope = app.Services.CreateScope();

    // Add pending migrations on startup
    ToDoDbContext toDoDbContext = scope.ServiceProvider.GetRequiredService<ToDoDbContext>();
    if (toDoDbContext.Database.GetPendingMigrations().Any())
    {
        toDoDbContext.Database.Migrate();
    }
}

app.UseHttpsRedirection();

app.MapGet("/api/todo", ([FromServices] ToDoDbContext context) =>
{
    return Results.Ok(context.GetToDos());
});

app.MapGet("/api/todo/{id}", async ([FromRoute] Guid id, [FromServices] ToDoDbContext context) =>
{
    return Results.Ok(await context.GetToDoByIdAsync(id));
});

app.MapPost("/api/todo", async ([FromBody] NewToDoItem toDo, [FromServices] ToDoDbContext context) =>
{
    var toDoItem = new ToDoItem { Title = toDo.Title, IsCompleted = false };

    return Results.Ok(await context.InsertToDoAsync(toDoItem));
});

app.MapPut("/api/todo/{id}", async (
    [FromRoute] Guid id, [FromBody] ToDoItem toDo, [FromServices] ToDoDbContext context) =>
{
    return id != toDo.Id
        ? Results.BadRequest()
        : context.ToDoExists(id) ? Results.Ok(await context.UpdateToDoAsync(toDo)) : Results.NotFound();
});

app.Run();
