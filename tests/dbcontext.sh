dotnet new uninstall /Users/moura/dev/templates/templates/dbcontext
dotnet new install /Users/moura/dev/templates/templates/dbcontext
dotnet new nett.dbcontext -h
rm -rf ./AppDbContext
dotnet new nett.dbcontext -o AppDbContext -ns Nett.Core.Context -ag User