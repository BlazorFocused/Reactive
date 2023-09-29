// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using BlazorFocused.Reactive.Redux.Store;
using BlazorFocused.Reactive.Redux.Test.TestBed.Extensions;
using BlazorFocused.Reactive.Redux.Test.TestBed.Models;
using Xunit.Abstractions;

namespace BlazorFocused.Reactive.Redux.Test.Store;

public partial class StoreTests
{
    protected readonly ServiceCollection serviceCollection;
    private readonly ITestOutputHelper testOutputHelper;

    public StoreTests(ITestOutputHelper testOutputHelper)
    {
        serviceCollection = new();
        this.testOutputHelper = testOutputHelper;
    }

    [Fact(DisplayName = "Should Store and Return Initial Value")]
    public void ShouldStoreAndReturnInitialValue()
    {
        SimpleClass inputSimpleClass = SimpleClassGenerator.GetRandomSimpleClass();
        SimpleClass expectedSimpleClass = inputSimpleClass;

        using var serviceProvider = new ServiceCollection()
            .BuildProviderWithTestLogger<Store<SimpleClass>>(testOutputHelper) as ServiceProvider;

        var store = new Store<SimpleClass>(inputSimpleClass, serviceProvider);

        SimpleClass actualSimpleClass = store.GetState();

        actualSimpleClass.Should().BeEquivalentTo(expectedSimpleClass);
    }

    [Fact(DisplayName = "Should Return 'null' when initialized as null")]
    public void ShouldReturnNullWhenInitializedAsNull()
    {
        using var serviceProvider = new ServiceCollection()
            .BuildProviderWithTestLogger<Store<SimpleClass>>(testOutputHelper) as ServiceProvider;

        var store = new Store<SimpleClass>(null, serviceProvider);

        SimpleClass actualSimpleClass = store.GetState();

        actualSimpleClass.Should().BeNull();
    }
}
