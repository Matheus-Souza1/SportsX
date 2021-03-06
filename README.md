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

## Como Rodar a atualização da Migration para criar o banco de dados(back)
Primeiro acessar o diretorio do projeto **SportsXs.Infra**
 ````
cd .\API\SportsXs.Infra\ 
````
Após isso basta rodar o comando 
```
dotnet ef database update -s ..\SportsXs.API\
```
**Observação**: Se por um acaso após o comando **dotnet ef** acusar algum erro relacionado ao EntityFrameworkCore.Tools, provavelmente a linha de comando ef possa estar desatualizada ou fora da versão esperada. Se esse for o caso basta rodar essa linha de comando no seu terminal.
```
dotnet tool update -g dotnet-ef
```

## Rodando a aplicação FrontEnd
Para rodar o projeto FrontEnd, siga esses passos.

**Instalando as Dependências**
```
 npm i
 ```
 **Rodando a aplicação**
 ```
 npm run start
```
