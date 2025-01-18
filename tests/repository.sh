dotnet new uninstall /Users/moura/dev/templates/templates/repository
dotnet new install /Users/moura/dev/templates/templates/repository
dotnet new nett.repository -h
rm -rf ./Persistence
dotnet new nett.repository -o Persistence -n User -ns Nett.Core.Persistence.Repositories 