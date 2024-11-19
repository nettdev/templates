dotnet new uninstall /Users/moura/dev/templates/endpoint
dotnet new install /Users/moura/dev/templates/endpoint
dotnet new nett.endpoint -h
rm -rf ./Endpoints
dotnet new nett.endpoint -o Endpoints -ag User --namespace Nett.Core.Userendpoint