#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

RUN apt-get -y update && apt-get install -y libxml2

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WindowsNET6App.csproj", "."]
RUN dotnet restore "./WindowsNET6App.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WindowsNET6App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WindowsNET6App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV PATH=$PATH:"/app/clidriver/lib"
ENV LD_LIBRARY_PATH="/app/clidriver/lib"

ENTRYPOINT ["dotnet", "WindowsNET6App.dll"]
