# AlocaFilme - API com versionamento de Endpoints

<br/>

### Url Heroku

https://aloca-filme.herokuapp.com/swagger/index.html


<br/>
<br/>

Objetivo:
- Criar uma estrutura base, separando responsabilidades de negocio, infraestrutura e endpoints.
- Realizar versionamento de `endpoints`
- Autenticação com `JWT`
- Retorno padronizado e inclusive erros
- Erros gerados serão incluidos em uma lista ao em vez de gerar um `New Error`
- Documentação da API utilizando `Swagger`
- Registro de Erros e Logs utilizando `Elmah.io` e `Logger`
- Implementar `ASP.NET Identity` com permissões de acesso com `Claims` e `Roles`
- Utilizar AutoMapper
- Subir aplicação no `IIS local` e no `Heroku`
- TODO - ~~Implementar Testes automatizados~~

<br/>
<br/>

## Tecnologias
- Banco de dados SQL Server
- .Net Core 3.1

## Frameworks e Packages
- EntityFramework
- Elmah.io
- FluentValidation
- Authentication JwtBearer
- Identity
- Api Version
- AutoMapper
- HealthChecks

<br/>
<br/>

<br>

## Como executar

Criar banco de dados com o nome `alocafilme`

Configurar conexão com o banco de dados no arquivo `appsettings.json`


```
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=alocafilme;Trusted_Connection=True;"
  },
```

<br>

Executar no terminal `Package Manager Console (PM)`:
<br>

```
add-migration createBanco -Context ApplicationDbContext --verbose
update-dabase -Context ApplicationDbContext --verbose
```

```
add-migration createBanco -Context MeuDbContext --verbose
update-dabase -Context MeuDbContext --verbose
```
<br>

`Build >> Clean Solution`
<br>
`Build >> Build Solution`

<br>


