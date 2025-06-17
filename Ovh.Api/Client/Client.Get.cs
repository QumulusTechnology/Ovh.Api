using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ovh.Api;

public partial class OvhApiClient
{
    /// <summary>
    /// Issues an async GET call
    /// </summary>
    /// <param name="target">API method to call</param>
    /// <param name="kwargs">Arguments to append to URL</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="OvhApiClient"/>'s timeout with a custom one</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Raw API response</returns>
    public Task<string> GetAsync(string target, QueryStringParams? kwargs = null, bool needAuth = true, TimeSpan? timeout = null, CancellationToken cancellationToken = default)
        => 
            CallAsync(HttpMethod.Get, $"{target}{kwargs}", null, needAuth, timeout: timeout, cancellationToken: cancellationToken);

    /// <summary>
    /// Issues an async batch GET call
    /// </summary>
    /// <param name="target">API method to call</param>
    /// <param name="kwargs">Arguments to append to URL</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="OvhApiClient"/>'s timeout with a custom one</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Raw API response</returns>
    public Task<string> GetBatchAsync(string target, QueryStringParams? kwargs = null, bool needAuth = true, TimeSpan? timeout = null, CancellationToken cancellationToken = default) 
        => 
            CallAsync(HttpMethod.Get, $"{target}{kwargs}", null, needAuth, isBatch: true, timeout: timeout, cancellationToken: cancellationToken);

    /// <summary>
    /// Issues an async GET call with an expected return type
    /// </summary>
    /// <typeparam name="T">Expected return type</typeparam>
    /// <param name="target">API method to call</param>
    /// <param name="kwargs">Arguments to append to URL</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="OvhApiClient"/>'s timeout with a custom one</param>
    /// <param name="cancellationToken"></param>
    /// <returns>API response deserialized to T by JSON.Net</returns>
    public Task<T?> GetAsync<T>(string target, QueryStringParams? kwargs = null, bool needAuth = true, TimeSpan? timeout = null, CancellationToken cancellationToken = default) 
        => 
            CallAsync<T>(HttpMethod.Get, $"{target}{kwargs}", null, needAuth, timeout: timeout, cancellationToken: cancellationToken);

    /// <summary>
    /// Issues an async batch GET call with an expected return type
    /// </summary>
    /// <typeparam name="T">Expected return type</typeparam>
    /// <param name="target">API method to call</param>
    /// <param name="kwargs">Arguments to append to URL</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="OvhApiClient"/>'s timeout with a custom one</param>
    /// <param name="cancellationToken"></param>
    /// <returns>API response deserialized to List&lt;T&gt; by JSON.Net</returns>
    public Task<List<T>?> GetBatchAsync<T>(string target, QueryStringParams? kwargs = null, bool needAuth = true, TimeSpan? timeout = null, CancellationToken cancellationToken = default) 
        => 
            CallAsync<List<T>>(HttpMethod.Get, $"{target}{kwargs}", null, needAuth, isBatch: true, timeout: timeout, cancellationToken: cancellationToken);
}