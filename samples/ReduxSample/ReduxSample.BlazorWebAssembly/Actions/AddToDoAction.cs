// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using ReduxSample.BlazorWebAssembly.Models;
using ReduxSample.BlazorWebAssembly.Services;
using ReduxSample.BlazorWebAssembly.Stores;
using BlazorFocused.Reactive.Redux;

namespace ReduxSample.BlazorWebAssembly.Actions;

public class AddToDoAction : StoreActionAsync<ToDoStore, NewToDo>
{
    private readonly IToDoService toDoService;

    public AddToDoAction(IToDoService toDoService)
    {
        this.toDoService = toDoService;
    }

    public override async ValueTask<ToDoStore> ExecuteAsync(NewToDo input)
    {
        ToDo newToDo = await toDoService.AddToDoAsync(input);

        State.InComplete.Add(newToDo);

        return State;
    }
}
