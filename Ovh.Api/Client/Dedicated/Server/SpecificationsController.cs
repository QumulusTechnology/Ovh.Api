using System.Threading;
using System.Threading.Tasks;
using Ovh.Api.Models;

namespace Ovh.Api.Dedicated.Server;

public class SpecificationsController: ControllerBase
{
    protected internal override string Path { get; }

    internal SpecificationsController(ControllerBase dedicatedServerController) : base(dedicatedServerController.OvhApiClient) 
        => 
            Path = $"{dedicatedServerController.Path}/specifications";

    public async Task<NetworkSpecification?> GetNetworkSpecificationAsync(CancellationToken cancellationToken = default) =>
        await OvhApiClient.GetAsync<NetworkSpecification>($"{Path}/network", cancellationToken: cancellationToken)
            .ConfigureAwait(false);

}