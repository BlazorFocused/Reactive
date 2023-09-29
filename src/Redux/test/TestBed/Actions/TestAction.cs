// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using BlazorFocused.Reactive.Redux.Test.TestBed.Models;

namespace BlazorFocused.Reactive.Redux.Test.TestBed.Actions;

public class TestAction : TestActionState<SimpleClass>
{
    public override SimpleClass Execute() => SimpleClassGenerator.GetRandomSimpleClass();
}
