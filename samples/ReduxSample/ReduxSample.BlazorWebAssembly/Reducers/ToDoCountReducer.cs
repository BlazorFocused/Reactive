// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using ReduxSample.BlazorWebAssembly.Models;
using ReduxSample.BlazorWebAssembly.Stores;
using BlazorFocused.Reactive.Redux;

namespace ReduxSample.BlazorWebAssembly.Reducers;

public class ToDoCountReducer : IReducer<ToDoStore, ToDoCount>
{
    public ToDoCount Execute(ToDoStore input)
    {
        int complete = input.Complete.Count;
        int incomplete = input.InComplete.Count;

        return new ToDoCount
        {
            Complete = complete,
            InComplete = incomplete,
            Total = complete + incomplete
        };
    }
}
