// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using BlazorFocused.Reactive.Redux.Test.TestBed.Models;

namespace BlazorFocused.Reactive.Redux.Test.TestBed.Actions;

public class TestActionWithInput : TestActionState<SimpleClass, string>
{
    public override SimpleClass Execute(string input) => SimpleClassGenerator.GetStaticSimpleClass(input);
}
