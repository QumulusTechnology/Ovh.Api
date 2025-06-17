using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using QCP.Helpers.Common.Json;

namespace Ovh.Api;

public partial class OvhApiClient
{
    /// <summary>
    /// Issues an async PUT call
    /// </summary>
    /// <param name="target">API method to call</param>
    /// <param name="json">Json string to send as body</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="OvhApiClient"/>'s timeout with a custom one</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Raw API response</returns>
    public Task<string> PutStringAsync(string target, string json, bool needAuth = true, TimeSpan? timeout = null, CancellationToken cancellationToken = default)
        => 
            CallAsync(HttpMethod.Put, target, json, needAuth, timeout: timeout, cancellationToken: cancellationToken);

    /// <summary>
    /// Issues an async PUT call
    /// </summary>
    /// <param name="target">API method to call</param>
    /// <param name="data">Object to be serialized and sent as a json body</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="OvhApiClient"/>'s timeout with a custom one</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Raw API response</returns>
    public Task<string> PutAsync(string target, object? data = null, bool needAuth = true, TimeSpan? timeout = null, CancellationToken cancellationToken = default) 
        => 
            CallAsync(HttpMethod.Put, target, data?.Serialize(), needAuth, timeout: timeout, cancellationToken: cancellationToken);

    /// <summary>
    /// Issues an async PUT call
    /// </summary>
    /// <typeparam name="T">Expected return type</typeparam>
    /// <param name="target">API method to call</param>
    /// <param name="json">Json string to send as body</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="OvhApiClient"/>'s timeout with a custom one</param>
    /// <param name="cancellationToken"></param>
    /// <returns>API response deserialized to T by JSON.Net</returns>
    public Task<T?> PutStringAsync<T>(string target, string json, bool needAuth = true, TimeSpan? timeout = null, CancellationToken cancellationToken = default) 
        => 
            CallAsync<T>(HttpMethod.Put, target, json, needAuth, timeout: timeout, cancellationToken: cancellationToken);

    /// <summary>
    /// Issues an async PUT call
    /// </summary>
    /// <typeparam name="T">Expected return type</typeparam>
    /// <param name="target">API method to call</param>
    /// <param name="data">Object to be serialized and sent as a json body</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="OvhApiClient"/>'s timeout with a custom one</param>
    /// <param name="cancellationToken"></param>
    /// <returns>API response deserialized to T by JSON.Net with Strongly typed object as input</returns>
    public Task<T?> PutAsync<T>(string target, object? data = null, bool needAuth = true, TimeSpan? timeout = null, CancellationToken cancellationToken = default) 
        => 
            CallAsync<T>(HttpMethod.Put, target, data?.Serialize(), needAuth, timeout: timeout, cancellationToken: cancellationToken);
}