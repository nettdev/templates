dotnet new uninstall ./templates/repository
dotnet new install ./templates/repository
dotnet new nett.repository -h
rm -rf ./Persistence
dotnet new nett.repository  -n User -p Nett.Project 