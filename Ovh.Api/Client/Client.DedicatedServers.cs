using Ovh.Api.Dedicated.Server;

namespace Ovh.Api;

partial class OvhApiClient
{
    private DedicatedServersController? _dedicatedServers;


    public DedicatedServersController DedicatedServers => _dedicatedServers ??= new DedicatedServersController(this);
}