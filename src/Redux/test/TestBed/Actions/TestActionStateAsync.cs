// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

namespace BlazorFocused.Reactive.Redux.Test.TestBed.Actions;

public abstract class TestActionStateAsync<TState> : StoreActionAsync<TState>
{
    public string CheckedPropertyId { get; set; }
}

public abstract class TestActionStateAsync<TState, TInput> : StoreActionAsync<TState, TInput>
{
    public string CheckedPropertyId { get; set; }
}
