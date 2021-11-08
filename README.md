# SportsXs
Projeto tem como intuito o gerenciamento de clientes da aplicação SportsXs.

## Tecnologias e práticas utilizadas na API
- ASP.NET Core com .NET 5
- Entity Framework Core
- LocalDb
- Swagger
- AutoMapper
- Injeção de Dependência
- Programação Orientada a Objetos
- Padrão Repository

## Tecnologias e práticas utilizadas no Front
- Material-UI
- Formik
- React-Text-Mask
- Axios
- Componentes

## Funcionalidades
- Cadastro, Listagem, Detalhes, Atualização e Remoção de Cliente.

## Como Rodar a atualização da Migration(back)
```
 (diretorio raiz do projeto)\Sportx\API\SportsXs.Infra> dotnet ef database update -s ..\SportsXs.API\
```

## Rodando a aplicação FrontEnd
```
 npm i  - (Instalando as dependencias)
 npm run start - (rodando a aplicação)
```
