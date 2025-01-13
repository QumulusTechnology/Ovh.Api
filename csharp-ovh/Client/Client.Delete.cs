using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ovh.Api;

public partial class Client
{
    /// <summary>
    /// Issues an async DELETE call
    /// </summary>
    /// <param name="target">API method to call</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="Client"/>'s timeout with a custom one</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Raw API response</returns>
    public Task<string> DeleteAsync(string target, bool needAuth = true, TimeSpan? timeout = null, CancellationToken cancellationToken = default) 
        => 
            CallAsync("DELETE", target, null, needAuth, timeout: timeout, cancellationToken: cancellationToken);

    /// <summary>
    /// Issues an async DELETE call
    /// </summary>
    /// <typeparam name="T">Expected return type</typeparam>
    /// <param name="target">API method to call</param>
    /// <param name="needAuth">If true, send authentication headers</param>
    /// <param name="timeout">If specified, overrides default <see cref="Client"/>'s timeout with a custom one</param>
    /// <param name="cancellationToken"></param>
    /// <returns>API response deserialized to T by JSON.Net</returns>
    public Task<T?> DeleteAsync<T>(string target, bool needAuth = true, TimeSpan? timeout = null, CancellationToken cancellationToken = default) 
        => 
            CallAsync<T>("DELETE", target, null, needAuth, timeout: timeout, cancellationToken: cancellationToken);
}