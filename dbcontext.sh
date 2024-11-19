dotnet new uninstall /Users/moura/dev/templates/dbcontext
dotnet new install /Users/moura/dev/templates/dbcontext
dotnet new nett.dbcontext -h
rm -rf ./Context
dotnet new nett.dbcontext -o Context --namespace Nett.Core.Context