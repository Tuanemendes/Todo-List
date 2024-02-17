# Todo List

Lista de Tarefas

## Descrição

A API de lista de tarefas é uma aplicação voltada para o gerenciamento de tarefas e afazeres.
Seu propósito é permitir aos usuários criar, atualizar, visualizar , excluir e filtrar as tarefas de maneira eficiente e organizada.

## Modelagem 

![image](https://github.com/Tuanemendes/Todo-List/assets/54903202/8389d467-24d5-4f07-822f-25bcfeb5a784)




## Pré-requisitos

[SDK .net versão 6.0.41]( https://dotnet.microsoft.com/pt-br/download/dotnet/6.0)  <br> 
[Vscode](https://code.visualstudio.com/download)  ou [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/) <br> 
[Docker](https://www.docker.com/products/docker-desktop/) version 20.10.23, build 7155243 
Bando de Dados: Imagem [docker do Postgresql](https://hub.docker.com/_/postgres) versão 16 <br>
Gerenciador de Banco de Dados: [pgAdmin 4](https://www.pgadmin.org/download/)  

## Instalação

Utilização da imagem do banco Postgresql 16 

```
docker run -p 5432:5432 --name postgres -e POSTGRES_PASSWORD=root -d postgres:16

```
Criação do arquivo docker compose para armazenar os dados e utilização da imagem

```
version: '3.5'

volumes:
  data:
  tmpfs:

services:
  database:
    image: postgres:16
    ports:
      - 5432:5432
    environment:
      - POSTGRES_PASSWORD=todolist
    volumes:
      - type: volume
        source: data
        target: /var/lib/postgresql/data
      - type: tmpfs
        target: /dev/shm
```

Para subir a imagem 
criar como o nome docker-compose-todolist.yml
e no local do arquivo executar o comando abaixo:

```
docker-compose -f .\docker-compose-todolist.yml up -d
```
Para rodar api  seguir os passoa a seguir: 

```bash
git clone https://github.com/Tuanemendes/Todo-List.git
cd todo-list-api // entrar na pasta da api

dotnet restore  //para restaurar as dependências do projeto

dotnet ef migrations add InitialCreate // ****se for necesssário , pois já está criado no projeto só como update ja deve criar a tabela com as colunas.

dotnet ef database update
dotnet run


```

Para acessar a api se caso não abrir automaticamente  os endpoints no swagger é necessário acessar pelo link abaixo:

```
https://localhost:7191/swagger/index.html

```
![image](https://github.com/Tuanemendes/Todo-List/assets/54903202/73b75e12-2510-4e3d-bfa8-a73ad0d10c7b)



## Status do Projeto
<div align="left">
  
![Badge em Desenvolvimento ](http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge )


## Tecnologias Utilizadas 

 .net 6.0.41 <br>
 (ORM) Entity Framework Core <br>
 PostgreSQL <br>
 Angular 17 <br>
 Docker <br>
 Swagger <br>

## Autor
Tuane Mendes 


