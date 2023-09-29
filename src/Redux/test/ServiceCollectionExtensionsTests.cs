// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using BlazorFocused.Reactive.Redux.Test.TestBed.Models;

namespace BlazorFocused.Reactive.Redux.Test;

public class ServiceCollectionExtensionsTests
{
    [Fact(DisplayName = "Should register store with initial state")]
    public void ShouldRegisterStore()
    {
        var simpleClass = new SimpleClass { FieldOne = "Test" };
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddStore(simpleClass);
        using ServiceProvider provider = serviceCollection.BuildServiceProvider();

        IStore<SimpleClass> store = provider.GetRequiredService<IStore<SimpleClass>>();

        Assert.NotNull(store);
        Assert.Equal(simpleClass.FieldOne, store.GetState().FieldOne);
    }
}
