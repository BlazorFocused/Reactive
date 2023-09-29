// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using ReduxSample.BlazorWebAssembly.Models;
using ReduxSample.BlazorWebAssembly.Services;
using ReduxSample.BlazorWebAssembly.Stores;
using BlazorFocused.Reactive.Redux;

namespace ReduxSample.BlazorWebAssembly.Actions;

public class RestoreToDoAction : StoreActionAsync<ToDoStore, ToDo>
{
    private readonly IToDoService toDoService;

    public RestoreToDoAction(IToDoService toDoService)
    {
        this.toDoService = toDoService;
    }

    public override async ValueTask<ToDoStore> ExecuteAsync(ToDo input)
    {
        ToDo restoredToDo = await toDoService.RestoreToDoAsync(input);

        State.InComplete.Add(restoredToDo);
        State.Complete.Remove(input);

        return State;
    }
}
