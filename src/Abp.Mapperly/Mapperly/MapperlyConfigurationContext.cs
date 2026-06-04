using Abp.Dependency;

namespace Abp.Mapperly;

public class MapperlyConfigurationContext
{
    public IIocManager IocManager { get; }

    public MapperlyConfigurationContext(IIocManager iocManager)
    {
        IocManager = iocManager;
    }
}
