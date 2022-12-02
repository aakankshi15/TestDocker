#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# install necessary packages
RUN apt update \
    && apt install -y libgdiplus libxkbcommon-x11-0 libc6 libc6-dev libgtk2.0-0 libnss3 libatk-bridge2.0-0 libx11-xcb1 libxcb-dri3-0 libdrm-common libgbm1 libasound2 libxrender1 libfontconfig1 libxshmfence1
RUN chmod +rwx .

WORKDIR /src
COPY ["TestDocker/TestDocker.csproj", "TestDocker/"]
RUN dotnet restore "TestDocker/TestDocker.csproj"
COPY . .
WORKDIR "/src/TestDocker"
RUN dotnet build "TestDocker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestDocker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestDocker.dll"]