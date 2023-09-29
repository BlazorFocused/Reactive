// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ReduxSample.Api;

public class ToDoDbContext : DbContext
{
    public DbSet<ToDoItem> ToDos { get; set; }

    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options) { }

    public IEnumerable<ToDoItem> GetToDos()
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        return ToDos;
    }

    public bool ToDoExists(Guid id)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        ToDoItem toDo = ToDos.Where(item => item.Id == id).FirstOrDefault();

        return toDo is not null;
    }

    public async Task<ToDoItem> GetToDoByIdAsync(Guid id)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        return await ToDos.FindAsync(id);
    }

    public async Task<ToDoItem> InsertToDoAsync(ToDoItem toDo)
    {
        EntityEntry<ToDoItem> entityEntry =
            await ToDos.AddAsync(toDo);
        await SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<ToDoItem> UpdateToDoAsync(ToDoItem toDo)
    {
        EntityEntry<ToDoItem> entityEntry = ToDos.Update(toDo);
        await SaveChangesAsync();

        return entityEntry.Entity;
    }
}
