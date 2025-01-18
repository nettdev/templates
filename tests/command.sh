dotnet new uninstall /Users/moura/dev/templates/templates/command
dotnet new install /Users/moura/dev/templates/templates/command
dotnet new nett.command -h
rm -rf ./Users/AddUser
dotnet new nett.command -o Users/AddUser -n AddUser -ag User -ns Nett.Core.Users 