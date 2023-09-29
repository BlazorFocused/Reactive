// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

namespace ReduxSample.BlazorWebAssembly.Models;

public class ToDo : NewToDo
{
    public Guid Id { get; set; }

    public bool IsCompleted { get; set; }
}

public class NewToDo
{
    public string Title { get; set; }
}
