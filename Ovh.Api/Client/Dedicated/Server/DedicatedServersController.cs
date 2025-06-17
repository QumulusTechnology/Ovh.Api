using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ovh.Api.Dedicated.Server;

public class DedicatedServersController : ControllerBase
{
    protected internal override string Path => "/dedicated/server";

    internal DedicatedServersController(OvhApiClient ovhApiClient) : base(ovhApiClient)
    {
    }

    public DedicatedServerController For(string serverName)
    {
        if (string.IsNullOrWhiteSpace(serverName))
            throw new ArgumentException("Server name cannot be null, empty or whitespace", nameof(serverName));
        return new DedicatedServerController(this, serverName);
    }

    public async Task<IEnumerable<string>?> GetNamesAsync(CancellationToken cancellationToken) =>
        await OvhApiClient.GetAsync<IEnumerable<string>>(Path, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

}