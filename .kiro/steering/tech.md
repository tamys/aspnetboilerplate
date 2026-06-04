# Technology Stack

## Target Framework

- Primary: .NET 10.0 (updated from .NET 9.0)
- Legacy support: .NET Framework 4.6.2

## Build System

- **Build Tool**: NUKE build system (cross-platform)
- **Project Format**: SDK-style .csproj files
- **Solution**: Abp.sln containing 50+ projects

## Core Dependencies

- **Castle Windsor**: Dependency injection and interception
- **Newtonsoft.Json**: JSON serialization
- **System.Text.Json**: Modern JSON APIs
- **System.Linq.Dynamic.Core**: Dynamic LINQ queries
- **JetBrains.Annotations**: Code annotations

## ORM Support

- Entity Framework Core (primary)
- Entity Framework 6.x (legacy)
- NHibernate
- Dapper
- MongoDB

## Integration Libraries

- AutoMapper (object mapping)
- SignalR (real-time communication)
- Hangfire/Quartz (background jobs)
- Redis (caching)
- MailKit (email)
- Log4Net (logging)
- FluentValidation (validation)
- OpenIddict (authentication)

## Common Commands

### Build
```powershell
# Windows
.\build.ps1

# Linux/Mac
./build.sh
```

### Build with NUKE
```bash
# Compile all projects
nuke Compile

# Run tests
nuke Test

# Create NuGet packages
nuke Pack
```

### Package Management
```powershell
# Create and push NuGet packages
.\nupkg\pack.ps1
.\nupkg\push-myget.ps1
```

### Clean Build Artifacts
```cmd
Delete-BIN-OBJ-Folders.bat
```

## Configuration Files

- **common.props**: Shared package metadata and versioning (current: 11.0.0)
- **Directory.Build.props**: MSBuild configuration for all projects
- **configureawait.props**: ConfigureAwait settings
- **global.json**: .NET SDK version pinning
- **NuGet.Config**: NuGet feed configuration

## Code Generation

- Uses Fody for IL weaving
- FodyWeavers.xml/xsd files in most projects
- Microsoft.SourceLink.GitHub for source debugging
