# Drugovich API

## Tutorial com o objetivo de rodar a aplicação
- Requisitos:
  - É necessário ter a versão 6 do .NET Core SDK ou Runtime;
  - É necessário ter o docker instalado na sua máquina;
  - É necessário ter o PostgreSQL em contêiner através do Docker (apenas para criar uma instância do servidor de banco de dados).

## PostgreSQL (Docker)
Para rodar este projeto usando um banco de dados em contêiner, utilize o padrão do `docker run` através do comando:

`docker run --name my-postgres -e POSTGRES_PASSWORD=mysecretpassword -d postgres`

Logo após rodar este comando, abra o diretório Drugovich.Presentation e rode os seguintes comandos via CLI:

`dotnet clean`

`dotnet restore`

`dotnet build`

`dotnet watch run`

Você será direcionado ao path `https://localhost:[porta]`, insira '/swagger/index.html' ao final da url (caso não carregue a página do Swagger):

![image](https://github.com/olucaslrc/Drugovich/assets/49102884/074865c4-b2b6-49f1-81c7-8214c87507ed)

Irá aparecer para você os endpoints disponíveis:

![image](https://github.com/olucaslrc/Drugovich/assets/49102884/b8b2fb06-44c7-471d-8b4c-22ba15c26d5f)

## Testando EndPoints
Para testar os endpoints, você precisará de um token, para gerar um basta fazer login com um e-mail (manager2-0@email.com) e senha (123) ou registrar um novo usuário:

![image](https://github.com/olucaslrc/Drugovich/assets/49102884/1e2f0555-8c9a-4509-a7c7-a24f352e7510)


![image](https://github.com/olucaslrc/Drugovich/assets/49102884/d22c232c-1447-42de-bb47-0265c25c7efd)
