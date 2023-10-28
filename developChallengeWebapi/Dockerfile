# Imagem de compilação
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copiar projeto e restaurar pacotes
COPY developChallengeWebapi/*.csproj ./developChallengeWebapi/
COPY developChallengeDomain/*.csproj ./developChallengeDomain/
COPY developChallenge.Infra/*.csproj ./developChallenge.Infra/
COPY developChallenge.Service/*.csproj ./developChallenge.Service/
COPY developChallenge.UnitTests/*.csproj ./developChallenge.UnitTests/
COPY Worker/*.csproj ./Worker/
RUN dotnet restore developChallengeWebapi/developChallenge.Web.Api.csproj

# Copiar todo o código
COPY . .

# Compilar e publicar a aplicação
RUN dotnet publish developChallengeWebapi/developChallenge.Web.Api.csproj -c Release -o out

# Imagem final
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out ./

# Expor porta
EXPOSE 80

# Comando para iniciar o container
ENTRYPOINT ["dotnet", "developChallenge.Web.Api.dll"]