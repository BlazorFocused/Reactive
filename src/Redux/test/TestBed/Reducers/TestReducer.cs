// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using BlazorFocused.Reactive.Redux.Test.TestBed.Models;

namespace BlazorFocused.Reactive.Redux.Test.TestBed.Reducers;

public class TestReducer : TestClass, IReducer<SimpleClass, SimpleClassSubset>
{
    public SimpleClassSubset Execute(SimpleClass input) => new()
    {
        FieldOne = input.FieldOne,
        FieldThree = input.FieldThree,
        FieldFive = input.FieldFive
    };
}
