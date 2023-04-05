# Define a imagem base
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Define o diretório de trabalho
WORKDIR /app

# Copia o arquivo de configuração do projeto e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o código fonte do projeto
COPY . ./

# Compila o projeto
RUN dotnet publish -c Release -o out

# Define a imagem base
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Define o diretório de trabalho
WORKDIR /app

# Copia o build do projeto .NET para o diretório correto
COPY --from=build-env /app/out .

# Expõe a porta do servidor
EXPOSE 80

# Define o comando de inicialização do contêiner
ENTRYPOINT ["dotnet", "webapi.dll"]