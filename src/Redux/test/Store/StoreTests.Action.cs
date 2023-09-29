// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using Bogus;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using BlazorFocused.Reactive.Redux.Store;
using BlazorFocused.Reactive.Redux.Test.TestBed.Actions;
using BlazorFocused.Reactive.Redux.Test.TestBed.Extensions;
using BlazorFocused.Reactive.Redux.Test.TestBed.Models;

namespace BlazorFocused.Reactive.Redux.Test.Store;

public partial class StoreTests
{
    [Fact(DisplayName = "Should execute action by instance")]
    public void ShouldExecuteActionByInstance()
    {
        SimpleClass originalClass = default;
        serviceCollection.AddTransient<TestAction>();

        using var store = new Store<SimpleClass>(
            originalClass,
            serviceCollection.BuildProviderWithTestLogger<Store<SimpleClass>>(testOutputHelper));

        store.GetState().Should().BeNull();

        store.Dispatch<TestAction>();

        store.GetState().Should().NotBeNull();
    }

    [Fact(DisplayName = "Should execute action with input by instance")]
    public void ShouldExecuteActionWithInputByInstance()
    {
        string input = new Faker().Random.String2(10);
        SimpleClass originalClass = default;
        SimpleClass expectedClass = SimpleClassGenerator.GetStaticSimpleClass(input);

        var serviceProvider =
            serviceCollection.AddTransient<TestActionWithInput>()
            .BuildProviderWithTestLogger<Store<SimpleClass>>(testOutputHelper) as ServiceProvider;

        using var store = new Store<SimpleClass>(originalClass, serviceProvider);

        store.GetState().Should().BeNull();

        store.Dispatch<TestActionWithInput, string>(input);

        store.GetState().Should().NotBeNull()
            .And.BeEquivalentTo(expectedClass);
    }

    [Fact(DisplayName = "Should execute action by type")]
    public void ShouldExecuteActionWithType()
    {
        SimpleClass originalClass = default;

        using var serviceProvider =
            serviceCollection.AddTransient<TestAction>()
            .BuildProviderWithTestLogger<Store<SimpleClass>>(testOutputHelper) as ServiceProvider;

        var store = new Store<SimpleClass>(originalClass, serviceProvider);

        store.GetState().Should().BeNull();

        store.Dispatch<TestAction>();

        store.GetState().Should().NotBeNull();
    }

    [Fact(DisplayName = "Should execute action with input by type")]
    public void ShouldExecuteActionWithInputByType()
    {
        string input = new Faker().Random.String2(10);
        SimpleClass originalClass = default;
        SimpleClass expectedClass = SimpleClassGenerator.GetStaticSimpleClass(input);

        using var serviceProvider =
            serviceCollection.AddTransient<TestActionWithInput>()
            .BuildProviderWithTestLogger<Store<SimpleClass>>(testOutputHelper) as ServiceProvider;

        var store = new Store<SimpleClass>(originalClass, serviceProvider);

        store.GetState().Should().BeNull();

        store.Dispatch<TestActionWithInput, string>(input);

        store.GetState().Should().NotBeNull()
            .And.BeEquivalentTo(expectedClass);
    }
}
