// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

namespace BlazorFocused.Reactive.Redux;

/// <inheritdoc cref="IAction{TState}"/>
public abstract class StoreAction<TState> : IAction<TState>
{
    /// <inheritdoc />
    public TState State { get; set; }

    /// <inheritdoc />
    public abstract TState Execute();
}

/// <inheritdoc cref="IAction{TState, TInput}"/>
public abstract class StoreAction<TState, TInput> : IAction<TState, TInput>
{
    /// <inheritdoc />
    public TState State { get; set; }

    /// <inheritdoc />
    public abstract TState Execute(TInput input);
}
