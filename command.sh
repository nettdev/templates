dotnet new uninstall /Users/moura/dev/templates/command
dotnet new install /Users/moura/dev/templates/command
dotnet new nett.command -h
rm -rf ./Operations/SomeOperation
dotnet new nett.command -o Operations/SomeOperation -c SomeOperation -ag Operation --namespace Nett.Core.Operations.SomeOperation 