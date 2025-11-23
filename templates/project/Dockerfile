FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS sdk
WORKDIR /api
COPY . /api
RUN dotnet publish -c Release -o dist src/Infrastructure

FROM node:24-alpine AS node
WORKDIR /spa
COPY . /spa
RUN npm install --prefix ./src/Presentation
RUN npm run build --prefix ./src/Presentation

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS dotnet-runtime
WORKDIR /app
COPY --from=sdk api/dist /app
COPY --from=node spa/dist /app/wwwroot
ENV ASPNETCORE_URLS=http://*:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "NameOverride.Infrastructure.dll"]