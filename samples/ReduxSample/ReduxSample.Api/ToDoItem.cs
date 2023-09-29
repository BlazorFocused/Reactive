// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReduxSample.Api;

public class ToDoItem : NewToDoItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public bool IsCompleted { get; set; }
}

public class NewToDoItem
{
    [Required]
    public string Title { get; set; }
}
