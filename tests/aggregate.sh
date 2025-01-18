dotnet new uninstall /Users/moura/dev/templates/templates/aggregate
dotnet new install /Users/moura/dev/templates/templates/aggregate
dotnet new nett.aggregate -h
rm -rf ./UserAggregate
dotnet new nett.aggregate -o UserAggregate -n User -va Address -e UserType -ns Nett.Core.UserAggregate