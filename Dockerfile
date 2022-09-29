#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /src
COPY ["WindowsNET6App.csproj", "."]
RUN dotnet restore "./WindowsNET6App.csproj"
COPY . .
RUN dotnet build "WindowsNET6App.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "WindowsNET6App.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:6.0
WORKDIR /app

ENV DB2_CLI_DRIVER_INSTALL_PATH="/app/clidriver" \
    LD_LIBRARY_PATH="/app/clidriver/lib" \
    LIBPATH="/app/clidriver/lib" \
    PATH=$PATH:"/app/clidriver/bin:/app/clidriver/lib"

RUN apt-get -y update && apt-get install -y libxml2

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WindowsNET6App.dll"]
