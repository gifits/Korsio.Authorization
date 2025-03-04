FROM mcr.microsoft.com/dotnet/sdk:9.0 AS builder
WORKDIR /src

COPY Gifits.Korsio.Authentication.Application/Gifits.Korsio.Authorization.Application.csproj Gifits.Korsio.Authentication.Application/
COPY Gifits.Korsio.Authentication.Domain/Gifits.Korsio.Authorization.Domain.csproj Gifits.Korsio.Authentication.Domain/
COPY Gifits.Korsio.Authentication.Infrastructure/Gifits.Korsio.Authorization.Infrastructure.csproj Gifits.Korsio.Authentication.Infrastructure/
COPY Gifits.Korsio.Authentication/Gifits.Korsio.Authorization.Api.csproj Gifits.Korsio.Authentication/

RUN dotnet restore Gifits.Korsio.Authentication/Gifits.Korsio.Authorization.Api.csproj

COPY . .
WORKDIR /src/Gifits.Korsio.Authentication
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=builder /app/out .

EXPOSE 80
EXPOSE 5024

CMD ["dotnet", "Gifits.Korsio.Authorization.Api.dll"]