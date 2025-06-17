using System;

namespace Ovh.Api;

public abstract class ControllerBase(OvhApiClient ovhApiClient)
{
    protected internal readonly OvhApiClient OvhApiClient = ovhApiClient ?? throw new ArgumentNullException(nameof(ovhApiClient));
    protected internal abstract string Path { get; }
}