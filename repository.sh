dotnet new uninstall /Users/moura/dev/templates/repository
dotnet new install /Users/moura/dev/templates/repository
dotnet new nett.repository -h
rm -rf ./Persistence
dotnet new nett.repository -o Persistence -ag User --namespace Nett.Core.Persistence.Repositories 