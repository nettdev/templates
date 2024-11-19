dotnet new uninstall /Users/moura/dev/templates/command
dotnet new install /Users/moura/dev/templates/command
dotnet new nett.command -h
rm -rf ./Users/AddUser
dotnet new nett.command -o Users/AddUser -c AddUser -ag User --namespace Nett.Core.Users 