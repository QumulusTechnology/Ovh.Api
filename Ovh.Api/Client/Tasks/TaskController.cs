using System.Threading;
using System.Threading.Tasks;
using Ovh.Api.Models;

namespace Ovh.Api.Tasks;

public class TaskController : ControllerBase
{
    protected internal override string Path { get; }

    internal TaskController(ControllerBase controllerBase, uint taskId) : base(controllerBase.OvhApiClient)
        =>
            Path = $"{controllerBase.Path}/{taskId}";

    public async Task<TaskInfo?> GetInfoAsync(CancellationToken cancellationToken = default)
        =>
            await OvhApiClient.GetAsync<TaskInfo>($"{Path}", cancellationToken: cancellationToken)
                .ConfigureAwait(false);
}