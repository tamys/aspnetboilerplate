using System;
using System.Collections.Generic;

namespace Abp.Mapperly;

public interface IAbpMapperlyConfiguration
{
    List<Action<MapperlyConfigurationContext>> Configurators { get; }
}
