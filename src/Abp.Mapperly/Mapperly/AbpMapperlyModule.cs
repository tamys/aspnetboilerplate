using System;
using System.Linq;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection;
using Castle.MicroKernel.Registration;

namespace Abp.Mapperly;

[DependsOn(typeof(AbpKernelModule))]
public class AbpMapperlyModule : AbpModule
{
    private readonly ITypeFinder _typeFinder;

    public AbpMapperlyModule(ITypeFinder typeFinder)
    {
        _typeFinder = typeFinder;
    }

    public override void PreInitialize()
    {
        IocManager.Register<IAbpMapperlyConfiguration, AbpMapperlyConfiguration>();

        Configuration.ReplaceService<ObjectMapping.IObjectMapper, MapperlyObjectMapper>();
    }

    public override void PostInitialize()
    {
        RegisterMappers();
        RunConfigurators();
    }

    private void RegisterMappers()
    {
        var mapperTypes = _typeFinder.Find(type =>
            typeof(IMapperlyMapper).IsAssignableFrom(type) &&
            type.IsClass &&
            !type.IsAbstract
        );

        foreach (var mapperType in mapperTypes)
        {
            if (!IocManager.IsRegistered(mapperType))
            {
                IocManager.IocContainer.Register(
                    Component.For<IMapperlyMapper, object>()
                        .ImplementedBy(mapperType)
                        .LifestyleTransient()
                        .Named(mapperType.FullName)
                );
            }
        }

        Logger.DebugFormat("Registered {0} Mapperly mapper classes", mapperTypes.Length);
    }

    private void RunConfigurators()
    {
        var context = new MapperlyConfigurationContext(IocManager);

        foreach (var configurator in Configuration.Modules.AbpMapperly().Configurators)
        {
            configurator(context);
        }
    }
}
