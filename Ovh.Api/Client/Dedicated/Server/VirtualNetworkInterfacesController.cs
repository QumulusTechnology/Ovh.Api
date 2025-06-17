using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ovh.Api.Dedicated.Server;

public class VirtualNetworkInterfacesController : ControllerBase
{
    protected internal override string Path { get; }

    internal VirtualNetworkInterfacesController(ControllerBase dedicatedServerController) : base(dedicatedServerController.OvhApiClient) 
        => 
            Path = $"{dedicatedServerController.Path}/virtualNetworkInterface";

    public async Task<IEnumerable<string>?> GetNamesAsync(string? filterByMode = null, CancellationToken cancellationToken = default) =>
        await OvhApiClient.GetAsync<IEnumerable<string>>(
                Path,
                string.IsNullOrWhiteSpace(filterByMode)
                    ? null
                    : [("mode", filterByMode)],
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);


    public VirtualNetworkInterfaceController this[string interfaceUuid] => new(this, interfaceUuid);
}