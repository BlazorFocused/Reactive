// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using ReduxSample.BlazorWebAssembly.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace ReduxSample.BlazorWebAssembly.Services;

public class ToDoService : IToDoService
{
    private readonly HttpClient httpClient;

    private readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public ToDoService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ToDo> AddToDoAsync(NewToDo toDo)
    {
        HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync("api/todo", toDo);

        Stream responseStream = await httpResponseMessage.Content.ReadAsStreamAsync();

        ToDo newToDo = JsonSerializer.Deserialize<ToDo>(responseStream, jsonSerializerOptions);

        return newToDo;
    }

    public async Task<ToDo> CompleteToDoAsync(ToDo toDo)
    {
        toDo.IsCompleted = true;

        return await PutAsync(toDo);
    }

    public async Task<IEnumerable<ToDo>> GetToDoItemsAsync() =>
        await httpClient.GetFromJsonAsync<IEnumerable<ToDo>>("api/todo", jsonSerializerOptions);

    public async Task<ToDo> RestoreToDoAsync(ToDo toDo)
    {
        toDo.IsCompleted = false;

        return await PutAsync(toDo);
    }

    private async Task<ToDo> PutAsync(ToDo toDo)
    {
        HttpResponseMessage httpResponseMessage =
            await httpClient.PutAsJsonAsync($"api/todo/{toDo.Id}", toDo);

        Stream responseStream = await httpResponseMessage.Content.ReadAsStreamAsync();

        return JsonSerializer.Deserialize<ToDo>(responseStream, jsonSerializerOptions);
    }
}
