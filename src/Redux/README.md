[![Nuget Version](https://img.shields.io/nuget/v/BlazorFocused.Reactive.Redux?logo=nuget)](https://www.nuget.org/packages/BlazorFocused.Reactive.Redux)
[![Nuget Downloads](https://img.shields.io/nuget/dt/BlazorFocused.Reactive.Redux?logo=nuget)](https://www.nuget.org/packages/BlazorFocused.Reactive.Redux)

# BlazorFocused Reactive Redux

Provides one single source of updating and retrieving a data store throughout entire application

## NuGet Packages

| Package                                                                                      | Description                                                                                      |
| -------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------ |
| [BlazorFocused.Reactive.Redux](https://www.nuget.org/packages/BlazorFocused.Reactive.Redux/) | Provides one single source of updating and retrieving a data store throughout entire application |

## Documentation

Please visit the [BlazorFocused.Reactive Documentation Site](https://BlazorFocused.github.io/Reactive/) for installation, getting started, and API documentation.

## Samples

Please visit and/or download our [BlazorFocused.Reactive.Redux Sample Solution](https://github.com/BlazorFocused/Reactive/tree/main/samples/ReduxSample) to get a more in-depth view of usage.

## Installation

```dotnetcli
dotnet add package BlazorFocused.Reactive.Redux
```

## Quick Start

### Blazor WebAssembly Startup

```csharp
public static async Task Main(string[] args)
{
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("#app");

    builder.Services.AddScoped(sp =>
        new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

    builder.Services.AddStore<TestStore>(new TestStore { FieldOne = "Initialized" })
        .AddTransient<TestAction>()
        .AddTransient<TestActionAsync>()
        .AddTransient<TestReducer>()
        .AddScoped<TestService>()
        .AddSingleton<TestSingletonService>();
    await builder.Build().RunAsync();
}
```

### State

Retrieve static state value from store:

```csharp
@inject IStore<TestStore> store;
...
store.GetState().FieldOne;
```

Retrieve state value and subscribe to store updates:

```csharp
@inject IStore<TestStore> store;
...
TestStore currentState = default;
store.Subscribe((newState) => {
    // update state used in page
    currentState = newState;
    // inform blazor page to refresh with state update
    StateHasChanged();
});
```

### Reducers

Subscribe to reduced value from store:

```csharp
@inject IStore<TestStore> store;
...
TestStoreSubset subsetState = default;
store.Reduce<TestReducer, TestStoreSubset>(reducedState =>
{
    // helpful if you do not care about the full state in your component
    subsetState = reducedState;
    // inform blazor page to refresh with state update
    StateHasChanged();
});
```

### Actions

Execute actions to update store:

```csharp
@inject IStore<TestStore> store;
...
TestStore currentState = default;
// call action to be committed
// if action updates state, component will update
store.Dispatch<TestAction>();
store.Subscribe((newState) => {
    // update state used in page
    currentState = newState;
    // inform blazor page to refresh with state update
    StateHasChanged();
});
```
