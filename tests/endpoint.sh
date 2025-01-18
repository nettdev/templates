dotnet new uninstall /Users/moura/dev/templates/templates/endpoint
dotnet new install /Users/moura/dev/templates/templates/endpoint
dotnet new nett.endpoint -h
rm -rf ./Endpoints
dotnet new nett.endpoint -o Endpoints -ag User -ns Nett.Core.Userendpoint