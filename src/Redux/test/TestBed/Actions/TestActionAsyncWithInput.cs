// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using BlazorFocused.Reactive.Redux.Test.TestBed.Models;
using BlazorFocused.Reactive.Redux.Test.TestBed.Services;

namespace BlazorFocused.Reactive.Redux.Test.TestBed.Actions;

public class TestActionAsyncWithInput : TestActionStateAsync<SimpleClass, string>
{
    private readonly TestService testService;

    public TestActionAsyncWithInput() { }

    public TestActionAsyncWithInput(TestService testService)
    {
        this.testService = testService;
    }

    public override async ValueTask<SimpleClass> ExecuteAsync(string input) =>
        await testService.GetValueAsync<string, SimpleClass>(input);
}
