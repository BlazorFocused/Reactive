// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

namespace BlazorFocused.Reactive.Redux;

/// <inheritdoc cref="IActionAsync{TState}"/>
public abstract class StoreActionAsync<TState> : IActionAsync<TState>
{
    /// <inheritdoc />
    public TState State { get; set; }

    /// <inheritdoc />
    public abstract ValueTask<TState> ExecuteAsync();
}

/// <inheritdoc cref="IActionAsync{TState, TInput}"/>
public abstract class StoreActionAsync<TState, TInput> : IActionAsync<TState, TInput>
{
    /// <inheritdoc />
    public TState State { get; set; }

    /// <inheritdoc />
    public abstract ValueTask<TState> ExecuteAsync(TInput input);
}
