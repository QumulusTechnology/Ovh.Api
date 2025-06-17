using System.Threading;
using System.Threading.Tasks;
using Ovh.Api.Models;

namespace Ovh.Api.Dedicated.Server;

public class VirtualNetworkInterfaceController : ControllerBase
{
    protected internal override string Path { get; }

    internal VirtualNetworkInterfaceController(ControllerBase parentController, string interfaceUuid): base(parentController.OvhApiClient) 
        => 
            Path = $"{parentController.Path}/{interfaceUuid}";

    public async Task<VirtualNetworkInterface?> GetInfoAsync(CancellationToken cancellationToken = default) =>
        await OvhApiClient.GetAsync<VirtualNetworkInterface>(
                Path,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

}