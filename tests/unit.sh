dotnet new uninstall /Users/moura/dev/templates/templates/unit
dotnet new install /Users/moura/dev/templates/templates/unit
dotnet new nett.unit -h
rm -rf ./unitTests
dotnet new nett.unit -o UnitTests -ag User -n AddUser -ns Nett.Core.UnitTests 