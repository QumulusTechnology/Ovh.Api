using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ovh.Api.Tasks;

public class TasksController : ControllerBase
{
    protected internal override string Path { get; }

    internal TasksController(ControllerBase controllerBase) : base(controllerBase.OvhApiClient) 
        => 
            Path = $"{controllerBase.Path}/task";

    public async Task<IEnumerable<uint>?> GetIdsAsync(CancellationToken cancellationToken = default)
        =>
            await OvhApiClient.GetAsync<IEnumerable<uint>>(Path, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

    public TaskController this[uint taskId] => new(this, taskId);
}