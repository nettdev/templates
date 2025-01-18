dotnet new uninstall /Users/moura/dev/templates/templates/integration
dotnet new install /Users/moura/dev/templates/templates/integration
dotnet new nett.integration -h
rm -rf ./IntegrationTests
dotnet new nett.integration -o IntegrationTests -n User -c AddUser --namespace Nett.Core.IntegrationTests