// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using BlazorFocused.Reactive.Redux.Test.TestBed.Models;
using BlazorFocused.Reactive.Redux.Test.TestBed.Services;

namespace BlazorFocused.Reactive.Redux.Test.TestBed.Actions;

public class TestActionAsync : TestActionStateAsync<SimpleClass>
{
    private readonly TestService testService;

    public TestActionAsync() { }

    public TestActionAsync(TestService testService)
    {
        this.testService = testService;
    }

    public override async ValueTask<SimpleClass> ExecuteAsync() => await testService.GetValueAsync<SimpleClass>();
}
