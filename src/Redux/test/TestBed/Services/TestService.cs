// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using BlazorFocused.Reactive.Redux.Test.TestBed.Models;

namespace BlazorFocused.Reactive.Redux.Test.TestBed.Services;

public class TestService : TestClass, ITestService
{
    public TestService() { }

    public virtual ValueTask<T> GetValueAsync<T>() => new(default(T));

    public virtual ValueTask<TOutput> GetValueAsync<TInput, TOutput>(TInput input) => new(default(TOutput));
}
