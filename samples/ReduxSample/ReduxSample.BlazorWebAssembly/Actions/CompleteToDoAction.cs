// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using ReduxSample.BlazorWebAssembly.Models;
using ReduxSample.BlazorWebAssembly.Services;
using ReduxSample.BlazorWebAssembly.Stores;
using BlazorFocused.Reactive.Redux;

namespace ReduxSample.BlazorWebAssembly.Actions;

public class CompleteToDoAction : StoreActionAsync<ToDoStore, ToDo>
{
    private readonly IToDoService toDoService;

    public CompleteToDoAction(IToDoService toDoService)
    {
        this.toDoService = toDoService;
    }

    public override async ValueTask<ToDoStore> ExecuteAsync(ToDo input)
    {
        ToDo completedToDo = await toDoService.CompleteToDoAsync(input);

        State.Complete.Add(completedToDo);
        State.InComplete.Remove(input);

        return State;
    }
}
