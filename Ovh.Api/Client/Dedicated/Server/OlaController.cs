using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ovh.Api.Models;

namespace Ovh.Api.Dedicated.Server;

public class OlaController:ControllerBase
{
    protected internal override string Path { get; }

    internal OlaController(ControllerBase dedicatedServerController) : base(dedicatedServerController.OvhApiClient) => Path = $"{dedicatedServerController.Path}/ola";

    public async Task<TaskInfo?> InitiateAggregationAsync(IEnumerable<VirtualNetworkInterface> interfaces, string bondName, CancellationToken cancellationToken = default) =>
        await OvhApiClient.PostAsync<TaskInfo>(
                $"{Path}/aggregation",
                new
                {
                    virtualNetworkInterfaces = interfaces.Select(i => i.Uuid),
                    name = bondName
                },
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

    public async Task<TaskInfo?> InitiateRestAsync(VirtualNetworkInterface @interface,CancellationToken cancellationToken = default) =>
        await OvhApiClient.PostAsync<TaskInfo>(
                $"{Path}/reset",
                new { virtualNetworkInterface = @interface.Uuid },
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);


}