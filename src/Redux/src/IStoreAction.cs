// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

namespace BlazorFocused.Reactive.Redux;

/// <summary>
/// Base interface of all store actions for interacting with store state
/// </summary>
/// <typeparam name="TState">Type of <see cref="IStore{TState}"/> state</typeparam>
public interface IStoreAction<TState>
{
    /// <summary>
    /// Store State
    /// </summary>
    TState State { get; set; }
}
