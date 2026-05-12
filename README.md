# UserSystem

Sistema de gerenciamento de usuários desenvolvido em ASP.NET Core 8.0, com arquitetura em camadas, persistência MySQL e APIs REST seguras.

## Visão geral

O `UserSystem` oferece um serviço de cadastro e manutenção de usuários, com cobertura para criação, listagem, consulta por ID, exclusão e atualização de dados.

## Tecnologias principais

- .NET 8.0
- ASP.NET Core Web API
- Entity Framework Core
- Pomelo MySQL Provider
- Argon2 para hashear senhas
- Swagger / OpenAPI

## Arquitetura

O projeto segue uma separação clara em camadas:

- `Application/DTO` - modelos de transferência de dados
- `Application/Services` - lógica de negócio e orquestração
- `Domain/Entities` - entidades de domínio
- `Domain/Interfaces` - contratos de repositório, hash de senha e outros serviços
- `Infrastructure/Context` - configuração do banco de dados EF Core
- `Infrastructure/Repositories` - implementação de repositório de usuários
- `Infrastructure/Security` - implementação de hashing de senha
- `Presentation/Controllers` - endpoints HTTP
- `Presentation/Middlewares` - tratamento global de exceções

## Recursos da API

A API expõe o controlador `UserController` com as seguintes rotas:

- `POST /user`
  - Cria um novo usuário
  - Payload: `name`, `email`, `password`
- `GET /user`
  - Retorna todos os usuários cadastrados
- `GET /user/{id}`
  - Retorna um usuário por ID
- `DELETE /user/{id}`
  - Remove um usuário por ID
- `PATCH /user/{id}/name`
  - Atualiza o nome do usuário
  - Payload: `name`
- `PATCH /user/{id}/email`
  - Atualiza o e-mail do usuário
  - Payload: `email`
- `PATCH /user/{id}/password`
  - Atualiza a senha do usuário
  - Payload: `password`

## Instalação

1. Certifique-se de ter o .NET 8 SDK instalado.
2. Configure uma instância MySQL.
3. Atualize a string de conexão `Default` em `src/appsettings.json` ou `src/appsettings.Development.json`:

```json
"ConnectionStrings": {
  "Default": "Server=localhost;Database=UserSystemDb;User=root;Password=sua_senha;"
}
```

4. Execute os comandos:

```bash
cd src
dotnet restore
```

## Execução

```bash
cd src
dotnet run
```

A aplicação será iniciada e, em ambiente de desenvolvimento, o Swagger UI ficará disponível para inspeção dos endpoints.

## Swagger

Ao executar a aplicação em `Development`, o Swagger é ativado automaticamente. Normalmente, o endereço será:

```text
https://localhost:5001/swagger
```

## Boas práticas e recomendações

- Mantenha as senhas fora do código-fonte e use variáveis de ambiente para `appsettings` em produção.
- Use migrações do Entity Framework Core para versionar o schema do banco.
- Adicione autenticação e autorização para proteger as rotas quando o sistema evoluir.

## Estrutura de arquivos

- `src/Program.cs` - configuração do pipeline da aplicação e DI
- `src/UserSystem.csproj` - dependências e metadados do projeto
- `src/Presentation/Controllers/UserController.cs` - APIs REST
- `src/Application/Services/UserService.cs` - regras de negócio de usuário
- `src/Infrastructure/Repositories/UserRepository.cs` - acesso a dados MySQL
- `src/Infrastructure/Security/PasswordHasher.cs` - hashing de senha com Argon2

## Observações finais

Este repositório é indicado como base para um sistema de gerenciamento de usuários simples, modular e preparado para extensão. A configuração atual já contempla API REST, persistência MySQL e boas práticas como validação de DTOs e tratamento global de exceções.
