# 1. Adım: .NET 8.0 SDK imajını kullanarak projeyi build edeceğiz
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WebApplication1/WebApplication1.csproj", "WebApplication1/"]
RUN dotnet restore "WebApplication1/WebApplication1.csproj"

# Tüm dosyaları kopyala
COPY . .
WORKDIR "/src/WebApplication1"
RUN dotnet build "WebApplication1.csproj" -c Release -o /app/build

# 2. Adım: Uygulamayı publish edeceğiz
FROM build AS publish
RUN dotnet publish "WebApplication1.csproj" -c Release -o /app/publish

# 3. Adım: Çalıştırmak için sadece çalıştırma ortamını ekliyoruz
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5093
ENV ASPNETCORE_URLS=http://+:5093
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
