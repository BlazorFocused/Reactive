// -------------------------------------------------------
// Copyright (c) BlazorFocused All rights reserved.
// Licensed under the MIT License
// -------------------------------------------------------

using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace BlazorFocused.Reactive.Redux.Test.TestBed.Extensions;

internal static class TestOutputHelperExtensions
{
    public static void WriteTestLoggerMessage(this ITestOutputHelper testOutputHelper,
        LogLevel level, string message, Exception exception)
    {
        string label = exception is null ?
                level.ToString() : exception.GetType().Name;

        if (exception is not null)
        {
            message += $" - {exception.Message}";
        }

        testOutputHelper.WriteLine($"{label}: {message}");
    }
}
