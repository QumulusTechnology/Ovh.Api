using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ovh.Api.Models;

namespace Ovh.Api;

partial class Client
{
    public async Task<NetworkSpecification?> GetNetworkSpecificationAsync(string serverName, CancellationToken cancellationToken = default) =>
        await GetAsync<NetworkSpecification>($"/dedicated/server/{serverName}/specifications/network", cancellationToken: cancellationToken).ConfigureAwait(false);

    public async Task<IEnumerable<string>?> GetVirtualNetworkInterfacesAsync(string serverName, string? filterByMode = null, CancellationToken cancellationToken = default) =>
        await GetAsync<IEnumerable<string>>(
            $"/dedicated/server/{serverName}/virtualNetworkInterface",new QueryStringParams{new (string, string?)[] { ("mode", filterByMode) }.Where(item=>item.Item2!= null).OfType<(string,string)>() },
            cancellationToken: cancellationToken).ConfigureAwait(false);

    public async Task<VirtualNetworkInterface?> GetVirtualNetworkInterfaceAsync(string serverName, string interfaceUuid, CancellationToken cancellationToken = default) =>
        await GetAsync<VirtualNetworkInterface>(
            $"/dedicated/server/{serverName}/virtualNetworkInterface/{interfaceUuid}",
            cancellationToken: cancellationToken).ConfigureAwait(false);

    public async Task<Server?> GetServerAsync(string serverName, CancellationToken cancellationToken) =>
        await GetServerAsync<Server>(serverName, cancellationToken).ConfigureAwait(false);

    public async Task<TServer?> GetServerAsync<TServer>(string serverName, CancellationToken cancellationToken) where TServer:Server=>
        await GetAsync<TServer>(
            $"/dedicated/server/{(string.IsNullOrWhiteSpace(serverName) ? throw new Exception("Server name cannot be null, empty or whitespace") : serverName)}",
            cancellationToken: cancellationToken).ConfigureAwait(false);

    public async Task<IEnumerable<string>?> GetServersAsync(CancellationToken cancellationToken) =>
        await GetAsync<IEnumerable<string>>("/dedicated/server", cancellationToken: cancellationToken).ConfigureAwait(false);

}