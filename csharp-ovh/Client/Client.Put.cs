using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ovh.Api;

public partial class Client
{
    /// <summary>
    /// Issues an async PUT call
    /// </summary>
    /// <param name="target">API method to call</param>
    /// <param name="json">Json string to send as body</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="Client"/>'s timeout with a custom one</param>
    /// <returns>Raw API response</returns>
    public Task<string> PutStringAsync(string target, string json, bool needAuth = true, TimeSpan? timeout = null)
        => 
            CallAsync("PUT", target, json, needAuth, timeout: timeout);

    /// <summary>
    /// Issues an async PUT call
    /// </summary>
    /// <param name="target">API method to call</param>
    /// <param name="data">Object to be serialized and sent as a json body</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="Client"/>'s timeout with a custom one</param>
    /// <returns>Raw API response</returns>
    public Task<string> PutAsync(string target, object? data = null, bool needAuth = true, TimeSpan? timeout = null) 
        => 
            CallAsync("PUT", target, data is null ? null : JsonSerializer.Serialize(data), needAuth, timeout: timeout);

    /// <summary>
    /// Issues an async PUT call
    /// </summary>
    /// <typeparam name="T">Expected return type</typeparam>
    /// <param name="target">API method to call</param>
    /// <param name="json">Json string to send as body</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="Client"/>'s timeout with a custom one</param>
    /// <returns>API response deserialized to T by JSON.Net</returns>
    public Task<T> PutStringAsync<T>(string target, string json, bool needAuth = true, TimeSpan? timeout = null) 
        => 
            CallAsync<T>("PUT", target, json, needAuth, timeout: timeout);

    /// <summary>
    /// Issues an async PUT call
    /// </summary>
    /// <typeparam name="T">Expected return type</typeparam>
    /// <param name="target">API method to call</param>
    /// <param name="data">Object to be serialized and sent as a json body</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="Client"/>'s timeout with a custom one</param>
    /// <returns>API response deserialized to T by JSON.Net with Strongly typed object as input</returns>
    public Task<T> PutAsync<T>(string target, object? data = null, bool needAuth = true, TimeSpan? timeout = null) 
        => 
            CallAsync<T>("PUT", target, data is null ? null : JsonSerializer.Serialize(data), needAuth, timeout: timeout);
}