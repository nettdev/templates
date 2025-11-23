dotnet new uninstall ./templates/endpoint
dotnet new install ./templates/endpoint
dotnet new nett.endpoint -h
rm -rf ./Endpoints
dotnet new nett.endpoint -n User -p Nett.Project