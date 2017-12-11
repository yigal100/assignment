FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
RUN npm install -g @angular/cli

FROM build AS build_with_angular
WORKDIR /src
COPY *.sln ./
COPY WebApi/WebApi.csproj WebApi/
RUN dotnet restore
COPY . .
WORKDIR /src/WebApi
RUN dotnet build -c Release -o /app

FROM build_with_angular AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApi.dll"]
