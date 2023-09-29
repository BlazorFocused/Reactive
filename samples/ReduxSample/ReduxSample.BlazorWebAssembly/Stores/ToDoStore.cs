// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using ReduxSample.BlazorWebAssembly.Models;

namespace ReduxSample.BlazorWebAssembly.Stores;

public class ToDoStore
{
    public List<ToDo> InComplete { get; set; } = new();

    public List<ToDo> Complete { get; set; } = new();
}
