dotnet new uninstall ./templates/aggregate
dotnet new install ./templates/aggregate
dotnet new nett.aggregate -h
rm -rf ./UserAggregate
dotnet new nett.aggregate -n User -va Address -e UserType -p Nett.Project