// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using BlazorFocused.Reactive.Redux.Store;
using BlazorFocused.Reactive.Redux.Test.TestBed.Extensions;
using BlazorFocused.Reactive.Redux.Test.TestBed.Models;
using BlazorFocused.Reactive.Redux.Test.TestBed.Reducers;

namespace BlazorFocused.Reactive.Redux.Test.Store;
public partial class StoreTests
{
    [Fact(DisplayName = "Should reduce state value with instance")]
    public void ShouldReduceStateValueWithInstance()
    {
        SimpleClass originalClass = SimpleClassGenerator.GetRandomSimpleClass();
        SimpleClassSubset originalReducedClass = new TestReducer().Execute(originalClass);
        SimpleClass updatedClass = SimpleClassGenerator.GetRandomSimpleClass();
        SimpleClassSubset updatedReducedClass = new TestReducer().Execute(updatedClass);

        using var serviceProvider = serviceCollection
            .AddTransient<TestReducer>()
            .BuildProviderWithTestLogger<Store<SimpleClass>>(testOutputHelper) as ServiceProvider;

        var store = new Store<SimpleClass>(originalClass, serviceProvider);

        SimpleClassSubset actualReducedState = default;

        store.Reduce<TestReducer, SimpleClassSubset>(reducedState =>
        {
            actualReducedState = reducedState;
        });

        actualReducedState.Should().BeEquivalentTo(originalReducedClass);

        store.SetState(updatedClass);

        actualReducedState.Should().BeEquivalentTo(updatedReducedClass);
    }

    [Fact(DisplayName = "Should reduce state value with type")]
    public void ShouldReduceStateValueWithType()
    {
        SimpleClass originalClass = SimpleClassGenerator.GetRandomSimpleClass();
        SimpleClassSubset originalReducedClass = new TestReducer().Execute(originalClass);
        SimpleClass updatedClass = SimpleClassGenerator.GetRandomSimpleClass();
        SimpleClassSubset updatedReducedClass = new TestReducer().Execute(updatedClass);

        using var serviceProvider =
            serviceCollection.AddTransient<TestReducer>()
            .BuildProviderWithTestLogger<Store<SimpleClass>>(testOutputHelper) as ServiceProvider;

        var store = new Store<SimpleClass>(originalClass, serviceProvider);

        SimpleClassSubset actualReducedState = default;

        store.Reduce<TestReducer, SimpleClassSubset>(reducedState =>
        {
            actualReducedState = reducedState;
        });

        actualReducedState.Should().BeEquivalentTo(originalReducedClass);

        store.SetState(updatedClass);

        actualReducedState.Should().BeEquivalentTo(updatedReducedClass);
    }
}
