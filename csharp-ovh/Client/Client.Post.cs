using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Ovh.Api;

public partial class Client
{
    /// <summary>
    /// Issues an async POST call
    /// </summary>
    /// <param name="target">API method to call</param>
    /// <param name="json">Json string to send as body</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="Client"/>'s timeout with a custom one</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Raw API response</returns>
    public Task<string> PostStringAsync(string target, string json, bool needAuth = true, TimeSpan? timeout = null, CancellationToken cancellationToken = default) 
        => 
            CallAsync("POST", target, json, needAuth, timeout: timeout, cancellationToken: cancellationToken);

    /// <summary>
    /// Issues an async POST call
    /// </summary>
    /// <param name="target">API method to call</param>
    /// <param name="data">Object to be serialized and sent as a json body</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="Client"/>'s timeout with a custom one</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Raw API response</returns>
    public Task<string> PostAsync(string target, object? data = null, bool needAuth = true, TimeSpan? timeout = null, CancellationToken cancellationToken = default) 
        => 
            CallAsync("POST", target, data is null ? null : JsonSerializer.Serialize(data), needAuth, timeout: timeout, cancellationToken: cancellationToken);

    /// <summary>
    /// Issues an async POST call.
    /// </summary>
    /// <typeparam name="T">Expected return type</typeparam>
    /// <param name="target">API method to call</param>
    /// <param name="json">Json string to send as body</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="Client"/>'s timeout with a custom one</param>
    /// <param name="cancellationToken"></param>
    /// <returns>API response deserialized to T by JSON.Net</returns>
    public Task<T?> PostStringAsync<T>(string target, string json, bool needAuth = true, TimeSpan? timeout = null, CancellationToken cancellationToken = default) 
        => 
            CallAsync<T>("POST", target, json, needAuth, timeout: timeout, cancellationToken: cancellationToken);

    /// <summary>
    /// Issues an aync POST call
    /// </summary>
    /// <typeparam name="T">Expected return type</typeparam>
    /// <param name="target">API method to call</param>
    /// <param name="data">Object to be serialized and sent as a json body</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="Client"/>'s timeout with a custom one</param>
    /// <param name="cancellationToken"></param>
    /// <returns>API response deserialized to T by JSON.Net with Strongly typed object as input</returns>
    public Task<T?> PostAsync<T>(string target, object? data = null, bool needAuth = true, TimeSpan? timeout = null, CancellationToken cancellationToken = default) 
        => 
            CallAsync<T>("POST", target, data is null ? null : JsonSerializer.Serialize(data), needAuth, timeout: timeout, cancellationToken: cancellationToken);
}