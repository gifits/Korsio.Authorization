FROM mcr.microsoft.com/dotnet/sdk:9.0 AS builder
WORKDIR /src

COPY Gifits.Korsio.Authorization.Application/Gifits.Korsio.Authorization.Application.csproj Gifits.Korsio.Authorization.Application/
COPY Gifits.Korsio.Authorization.Domain/Gifits.Korsio.Authorization.Domain.csproj Gifits.Korsio.Authorization.Domain/
COPY Gifits.Korsio.Authorization.Infrastructure/Gifits.Korsio.Authorization.Infrastructure.csproj Gifits.Korsio.Authorization.Infrastructure/
COPY Gifits.Korsio.Authorization.Api/Gifits.Korsio.Authorization.Api.csproj Gifits.Korsio.Authorization.Api/

RUN dotnet restore Gifits.Korsio.Api/Gifits.Korsio.Authorization.Api.csproj

COPY . .
WORKDIR /src/Gifits.Korsio.Authorization.Api
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=builder /app/out .

EXPOSE 80
EXPOSE 5024

CMD ["dotnet", "Gifits.Korsio.Authorization.dll"]