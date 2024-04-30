# ScreenSound

## Description

ScreenSound is a project developed while studying the C# and .NET Core ecosystem through Alura's course. It encompasses
a Console Application, two class libraries (ScreenSound.Shared.Dados for data access management and
ScreenSound.Shared.Modelos for business rules and models), and an ASP.NET Core Web API project serving data to an API.

The API routes and schemas are thoroughly documented using Swagger UI, accessible via the `/swagger` route.

## How to run

To run the project, ensure you have the .NET Core SDK installed on your machine. If not, you can download it from the
official website: [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).

Afterward, clone the repository and navigate to the root folder of the project. Run the following command:

```bash
dotnet run --project ScreenSound.Api
```

You'll also need SQL Server installed on your machine. Update the database with Entity Framework Core by executing the
Update Database command with the latest migration.

## About the project

The project is a simple CRUD application for managing Artists, Musics, and Genres. Data is stored in a SQL Server
database, and the API serves it to clients.

You can add an artist, a music, and a genre, and associate them. The API will return the data with the associations.

Additionally, the DTO pattern is implemented to prevent circular references between entities and enhance data
visualization.

## Technologies

- **.NET 8.0**: A powerful framework for building applications.
- **ASP.NET Core 6.4.0**: Used for creating web APIs and applications.
- **Swagger 6.5.0**: Describes and visualizes APIs.
- **Swagger UI**: Provides an interactive API documentation.
- **Microsoft.Data.SqlClient (Version 5.2.0)**: Connects to SQL Server databases.
- **Microsoft.EntityFrameworkCore packages (Version 8.0.4)**: Facilitates database operations.
    - **Microsoft.EntityFrameworkCore.Design**: Tools for database design.
    - **Microsoft.EntityFrameworkCore.SqlServer**: Adds SQL Server support.
    - **Microsoft.EntityFrameworkCore.Tools**: Command-line tools.
    - **Microsoft.EntityFrameworkCore.Proxies**: Enables lazy loading.
- **Microsoft.AspNetCore.OpenApi (Version 8.0.3)**: Generates API documentation.
- **Swashbuckle.AspNetCore (Version 6.4.0)**: Documents ASP.NET Core APIs.
- **Swashbuckle.AspNetCore.Swagger (Version 6.5.0)**: Exposes Swagger JSON endpoints.

---

# ScreenSound

## Descrição

ScreenSound é um projeto desenvolvido durante o estudo do ecossistema C# e .NET Core através do curso da Alura. Ele
inclui um aplicativo de console, duas bibliotecas de classes (ScreenSound.Shared.Dados para gerenciamento de acesso a
dados e ScreenSound.Shared.Modelos para regras de negócio e modelos), e um projeto ASP.NET Core Web API que fornece
dados para uma API.

As rotas e esquemas da API são documentados detalhadamente usando o Swagger UI, acessível pela rota `/swagger`.

## Como executar

Para executar o projeto, certifique-se de ter o SDK .NET Core instalado em sua máquina. Caso contrário, você pode
baixá-lo no site oficial: [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).

Depois, clone o repositório e navegue até a pasta raiz do projeto. Execute o seguinte comando:

```bash
dotnet run --project ScreenSound.Api
```

Você também precisará ter o SQL Server instalado em sua máquina. Atualize o banco de dados com o Entity Framework Core
executando o comando de atualização de banco de dados com a última migração.

## Sobre o projeto

O projeto é uma aplicação CRUD simples para gerenciar Artistas, Músicas e Gêneros. Os dados são armazenados em um banco
de dados SQL Server, e a API os serve para os clientes.

Você pode adicionar um artista, uma música e um gênero, e associá-los. A API retornará os dados com as associações.

Além disso, o padrão DTO é implementado para evitar referências circulares entre entidades e melhorar a visualização dos
dados.

## Tecnologias

- **.NET 8.0**: Uma estrutura poderosa para construir aplicativos.
- **ASP.NET Core 6.4.0**: Usado para criar APIs e aplicativos da web.
- **Swagger 6.5.0**: Descreve e visualiza APIs.
- **Swagger UI**: Fornece uma documentação interativa da API.
- **Microsoft.Data.SqlClient (Versão 5.2.0)**: Conecta-se a bancos de dados SQL Server.
- **Pacotes Microsoft.EntityFrameworkCore (Versão 8.0.4)**: Facilita operações de banco de dados.
    - **Microsoft.EntityFrameworkCore.Design**: Ferramentas para design de banco de dados.
    - **Microsoft.EntityFrameworkCore.SqlServer**: Adiciona suporte ao SQL Server.
    - **Microsoft.EntityFrameworkCore.Tools**: Ferramentas de linha de comando.
    - **Microsoft.EntityFrameworkCore.Proxies**: Permite o carregamento preguiçoso.
- **Microsoft.AspNetCore.OpenApi (Versão 8.0.3)**: Gera documentação da API.
- **Swashbuckle.AspNetCore (Versão 6.4.0)**: Documenta APIs do ASP.NET Core.
- **Swashbuckle.AspNetCore.Swagger (Versão 6.5.0)**: Expõe endpoints JSON do Swagger.
