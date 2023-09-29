// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ReduxSample.BlazorWebAssembly;
using ReduxSample.BlazorWebAssembly.Actions;
using ReduxSample.BlazorWebAssembly.Reducers;
using ReduxSample.BlazorWebAssembly.Services;
using ReduxSample.BlazorWebAssembly.Stores;
using BlazorFocused.Reactive.Redux;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        // API Address
        BaseAddress = new Uri("https://localhost:7042")
    });

builder.Services.AddStore<ToDoStore>(new())
    .AddTransient<AddToDoAction>()
    .AddTransient<GetAllToDoAction>()
    .AddTransient<CompleteToDoAction>()
    .AddTransient<RestoreToDoAction>()
    .AddTransient<ToDoCountReducer>();

builder.Services.AddTransient<IToDoService, ToDoService>();

await builder.Build().RunAsync();
