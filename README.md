# Nett Templates

## Overview

**Nett Templates** is a collection of ready-to-use project boilerplates and code generators that follow **Clean Architecture** and **Domain-Driven Design (DDD)** principles for .NET/C# applications. The templates are designed for use with `dotnet new` and include full project scaffolds, as well as modular generators for aggregates, commands, queries, CRUD operations, endpoints, and repositories.

## Features

- **Clean Architecture** layout: Domain, Application, Infrastructure, Presentation
- **DDD** support: Aggregates, Entities, Value Objects, Enumerations, Repositories
- **CQRS** without MediatR: Separate Commands and Queries
- **Minimal APIs**
- **Entity Framework Core** with Fluent Configurations
- Pre-configured **unit tests** (xUnit) and **integration tests**
- Docker support with multi-stage Dockerfile
- GitHub Actions for CI/CD (build, test, publish)
- VS Code debugging setup
- Scripts for easy local template installation

## Quick Start

### 1. Install Templates 

Install from NuGet:

```bash
dotnet new install Nett.Templates::0.3.0
```

Or run the individual installation scripts:

```bash
./scripts/project.sh
./scripts/aggregate.sh
./scripts/command.sh
./scripts/crud.sh
./scripts/endpoint.sh
./scripts/query.sh
./scripts/repository.sh
```

### 2. List Installed Templates

```bash
dotnet new list | grep nett
```

### 3. Create a New Project

```bash
dotnet new nett.project -n MyApp
cd MyApp
dotnet run
```

### 4. Add Features to Existing Project

```bash
dotnet new nett.crud -n Post -p DemoProject
dotnet new nett.aggregate -n Post -e PostType -p DemoProject
dotnet new nett.command -n CreatePost -p DemoProject
dotnet new nett.query -n GetPostList -p DemoProject
dotnet new nett.endpoint -n Post -p DemoProject
dotnet new nett.repository -n Post -p DemoProject
```

## Available Templates

| Name | Command | Description |
|------|---------|-------------|
| Project | `dotnet new nett.project` | Full Clean Architecture solution with tests, Docker, CI |
| Aggregate | `dotnet new nett.aggregate` | Domain Aggregate Root with Value Objects and Repository interface |
| Command | `dotnet new nett.command` | CQRS Command without MediatR |
| Query | `dotnet new nett.query` | CQRS Query without MediatR |
| CRUD | `dotnet new nett.crud` | Full CRUD: Aggregate, Commands, Queries, Repository, Endpoint, Tests |
| Endpoint | `dotnet new nett.endpoint` | Minimal API Endpoint group |
| Repository | `dotnet new nett.repository` | EF Core Repository and Configuration |

## Uninstall

```bash
dotnet new uninstall Nett.Templates
```

## Contributing

1. Fork and clone
2. Install local templates with scripts
3. Test with `dotnet new` commands
4. Update templates in `templates/` folder
5. Run `dotnet pack` and test install

## License

[MIT](LICENSE)
