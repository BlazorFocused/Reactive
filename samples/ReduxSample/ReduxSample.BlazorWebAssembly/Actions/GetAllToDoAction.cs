// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using ReduxSample.BlazorWebAssembly.Models;
using ReduxSample.BlazorWebAssembly.Services;
using ReduxSample.BlazorWebAssembly.Stores;
using BlazorFocused.Reactive.Redux;

namespace ReduxSample.BlazorWebAssembly.Actions;

public class GetAllToDoAction : StoreActionAsync<ToDoStore>
{
    private readonly IToDoService toDoService;

    public GetAllToDoAction(IToDoService toDoService)
    {
        this.toDoService = toDoService;
    }

    public override async ValueTask<ToDoStore> ExecuteAsync()
    {
        IEnumerable<ToDo> toDos = await toDoService.GetToDoItemsAsync();

        State.Complete = toDos.Where(toDo => toDo.IsCompleted == true).ToList();
        State.InComplete = toDos.Where(toDo => toDo.IsCompleted == false).ToList();

        return State;
    }
}
