// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

namespace BlazorFocused.Reactive.Redux.Test.TestBed.Services;

public interface ITestService
{
    ValueTask<T> GetValueAsync<T>();

    ValueTask<TOutput> GetValueAsync<TInput, TOutput>(TInput input);
}
