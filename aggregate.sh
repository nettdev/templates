dotnet new uninstall /Users/moura/dev/templates/aggregate
dotnet new install /Users/moura/dev/templates/aggregate
dotnet new nett.aggregate -h
rm -rf ./UserAggregate
dotnet new nett.aggregate -o UserAggregate -ag User -va Address -e UserType --namespace Nett.Core.UserAggregate