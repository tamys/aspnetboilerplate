# Project Structure

## Repository Layout

```
/
├── src/              # Source code (30+ projects)
├── test/             # Test projects
├── doc/              # Documentation
├── nupkg/            # NuGet packaging scripts
├── tools/            # Build tools
└── build/            # NUKE build project
```

## Source Organization

Projects follow a modular structure with clear separation of concerns:

### Core Framework
- **Abp**: Core framework with DDD building blocks, dependency injection, module system
- **Abp.Web.Common**: Shared web functionality
- **Abp.Web.Resources**: Client-side resources

### Web Frameworks
- **Abp.AspNetCore**: ASP.NET Core integration
- **Abp.AspNetCore.SignalR**: Real-time communication
- **Abp.AspNetCore.OData**: OData support
- **Abp.AspNetCore.OpenIddict**: Authentication

### Data Access
- **Abp.EntityFramework**: EF 6.x integration
- **Abp.EntityFrameworkCore**: EF Core integration
- **Abp.EntityFramework.Common**: Shared EF abstractions
- **Abp.NHibernate**: NHibernate integration
- **Abp.Dapper**: Dapper integration
- **Abp.MongoDB**: MongoDB integration
- **Abp.MemoryDb**: In-memory database for testing

### Module Zero (Identity & Multi-Tenancy)
- **Abp.Zero.Common**: Shared Zero module code
- **Abp.ZeroCore**: ASP.NET Core Identity integration
- **Abp.ZeroCore.EntityFrameworkCore**: EF Core for Zero
- **Abp.Zero.Ldap**: LDAP authentication

### Integration Modules
- **Abp.AutoMapper**: Object-to-object mapping
- **Abp.HangFire**: Background job processing
- **Abp.Quartz**: Scheduled job processing
- **Abp.RedisCache**: Redis caching
- **Abp.MailKit**: Email sending
- **Abp.Castle.Log4Net**: Logging
- **Abp.BlobStoring**: Binary large object storage
- **Abp.FluentValidation**: Validation

### Testing
- **Abp.TestBase**: Base classes for testing
- **Abp.AspNetCore.TestBase**: ASP.NET Core testing utilities

## N-Layer Architecture

Projects typically follow this layering:

1. **Presentation Layer**: MVC controllers, views, client apps
2. **Distributed Service Layer**: Web API controllers, OData endpoints
3. **Application Layer**: Application services, DTOs
4. **Domain Layer**: Entities, domain services, repositories (interfaces)
5. **Infrastructure Layer**: Repository implementations, external integrations

## Naming Conventions

- **Projects**: `Abp.[Feature]` or `Abp.[Technology].[Feature]`
- **Namespaces**: Match folder structure
- **Tests**: `Abp.[Feature].Tests`

## Key Folders in Core Project (Abp)

- `/Application`: Application services base classes
- `/Authorization`: Authorization infrastructure
- `/Domain`: DDD building blocks (entities, repositories, domain services)
- `/Events`: Event bus and domain events
- `/Localization`: Localization system
- `/Modules`: Module system
- `/MultiTenancy`: Multi-tenancy infrastructure
- `/Runtime`: Session, caching
- `/Configuration`: Settings management
- `/Auditing`: Audit logging
- `/BackgroundJobs`: Background job system
- `/Notifications`: Notification system

## Documentation

- `/doc/WebSite`: Markdown documentation files
- `/doc/api`: API documentation project
- Documentation organized by feature/topic
