// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

namespace BlazorFocused.Reactive.Redux.Test.TestBed.Actions;

public abstract class TestActionState<TState> : StoreAction<TState>
{
    public string CheckedPropertyId { get; set; }
}

public abstract class TestActionState<TState, TInput> : StoreAction<TState, TInput>
{
    public string CheckedPropertyId { get; set; }
}
