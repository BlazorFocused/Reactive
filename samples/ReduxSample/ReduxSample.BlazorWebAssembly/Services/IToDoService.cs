// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using ReduxSample.BlazorWebAssembly.Models;

namespace ReduxSample.BlazorWebAssembly.Services;

public interface IToDoService
{
    public Task<ToDo> AddToDoAsync(NewToDo toDo);

    public Task<IEnumerable<ToDo>> GetToDoItemsAsync();

    public Task<ToDo> CompleteToDoAsync(ToDo toDo);

    public Task<ToDo> RestoreToDoAsync(ToDo toDo);
}
