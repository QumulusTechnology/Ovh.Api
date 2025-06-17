using Ovh.Api.Models;
using Ovh.Api.Tasks;
using System.Threading;
using System.Threading.Tasks;

namespace Ovh.Api.Dedicated.Server;

public class DedicatedServerController : ControllerBase
{
    private SpecificationsController? _specificationsController;
    private VirtualNetworkInterfacesController? _virtualNetworkInterfacesController;
    private OlaController? _ola;
    private TasksController? _tasksController;

    protected internal override string Path { get; }
    public SpecificationsController Specifications => _specificationsController ??= new(this);

    public VirtualNetworkInterfacesController VirtualNetworkInterfaces => _virtualNetworkInterfacesController ??= new(this);

    public OlaController Ola => _ola ??= new(this);

    public TasksController Tasks => _tasksController ??= new(this);

    internal DedicatedServerController(ControllerBase dedicatedServersController, string serverName) : base(dedicatedServersController.OvhApiClient)
        =>
            Path = $"{dedicatedServersController.Path}/{serverName}";

    public async Task<Models.Server?> GetInfoAsync(CancellationToken cancellationToken = default) =>
        await GetInfoAsync<Models.Server>(cancellationToken)
            .ConfigureAwait(false);

    public async Task<TServer?> GetInfoAsync<TServer>(CancellationToken cancellationToken = default) where TServer : Models.Server =>
        await OvhApiClient.GetAsync<TServer>(Path, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

    /// <summary>
    /// Reinstall the server with the given parameters.
    /// </summary>
    /// <param name="request">Reinstall request parameters.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>TaskInfo for the reinstall operation.</returns>
    public async Task<TaskInfo?> ReinstallAsync(ReinstallRequest request, CancellationToken cancellationToken = default) =>
        await OvhApiClient.PostAsync<TaskInfo>($"{Path}/reinstall", request, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
}