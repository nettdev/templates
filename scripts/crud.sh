dotnet new uninstall ./templates/crud
dotnet new install ./templates/crud
dotnet new nett.crud -h
rm -rf ./src
dotnet new nett.crud -n User -vo Address -e UserType -ns Nett.BackOffice -o crud
