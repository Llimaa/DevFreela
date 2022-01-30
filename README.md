# DevFreela

Projeto realizado no módulo **Formação ASP NET Core**, utilizando .NET 5.

No desenvolvimento desse projeto, foi utilizado vários recursos como:
- Swagger
- Arquitetura Limpa
- Entity Framework Core
- Dapper 
- CQRS
- MediatR
- JWT
- xUnit

Mas quais funcionalidades foram implementadas?

- Cadastro, Atualização, Cancelamento e Consulta de Serviço de Freelancers.
- Cadastro de Usuário e de perfis Freelancer e Cliente
- Adicionar comentários para um serviço de Freelancer
- Definir, iniciar e finalizar o projeto
---

## Swagger

Ferramenta que simplifica a documentação e testes na API. Ele consegue gerar uma interface gráfica contendo todos os pontos de acesso (Endpoints) da API, permitindo realizar requisições diretamente em sua interface.
![image](https://user-images.githubusercontent.com/76961685/128607463-b449e0ca-1b39-4cce-9b8e-38fb1fa469e2.png)

---
## Arquitetura Limpa

Também conhecida como **Onion Architecture**, ou Arquitetura Cebola.
Tem como foco o **domínio** do sistema, tendo em sua essência o DDD - Domain Driven Design, sendo dividida em 4 camadas principais:

- Core, Infrastructure, Application e API
![image](https://user-images.githubusercontent.com/76961685/128607691-bbeeb09f-aeaf-4baa-8019-fcd73942ca5a.png)

---

## Entity Framework Core

É um ORM open-source e mantida pela Microsoft. Esse ORM simplifica o acesso a base de dados.
Os pacotes a serem utilizados são:

~~~ csharp
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
using Microsoft.EntityFrameworkCore;
~~~
![image](https://user-images.githubusercontent.com/76961685/128608246-d12db8a9-384f-4768-baba-f33989824431.png)

---

## Dapper

Um micro ORM para ajudar no acesso a dados, por ser mum micro orm ele é mais simples e peformatico que o Entity Framework Core.
Podemos utilizar ele em conjunto com o Entity Framework Core, onde o  Entity Framework vai acelerar nosso desenvolvimento para acesso a base de dados, e o Dapper vai ser nos ajudar a realizar interações mais peformaticas na base de dados.

- Apresenta métodos de extensão ao **IDbConnection** (no caso de Sql.Server, SqlConnection)

~~~ csharp
using Dapper;
~~~
![image](https://user-images.githubusercontent.com/76961685/128608179-b25a1d15-a999-4312-bc26-fd60d3cd110a.png)

--- 

## CQRS

~~~ csharp
Command-Query Responsability Segregation
~~~
Padrão de desenvolvimento que separa as consultas (**Queries**) das ações que alteram o estado do sistema (**Commands**).

Melhora a legibilidade da aplicação, além de permitir maior separação de responsabilidades e estimula separação de modelos.
![image](https://user-images.githubusercontent.com/76961685/128608304-837169e1-c5de-4d4e-b518-d18860fc2429.png)

---

## MediatR

Uma lib que implementa o padrão de projetos comportamental especificado pela GoF.
Tem suporte a **Commands** e **Queries**, delegando eles para serem processados pelos seus respectivos **Handlers**
Pacote *MediatR*
~~~ csharp
MediatR.Extensions.Microsoft.DependencyInjection
~~~
![image](https://user-images.githubusercontent.com/76961685/128608476-44424e3c-f0bc-49a5-999a-5e9867fbdd35.png)

---

## Json Web Token - JWT

É um padrão da Internet para a criação de dados com assinatura.
O JWT é enviado via cabeçalho Authorization.
![image](https://user-images.githubusercontent.com/76961685/128608610-bafab7cf-0145-49bc-99d0-e5e0b49e9d8a.png)

---

## xUnit

Ferramenta gratuita, open-source para auxiliar no desenvolvimento de testes unitários.
Exemplo de como utilizar essa LIB:

~~~ csharp
public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project("Nome De Teste", "Descricao de Teste", 1, 2, 10000);
            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);
            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);
            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);
            project.Start();
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
        }
    }
