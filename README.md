# Simple Pag - Solução de Gerenciamento de Pagamentos

Esta solução é uma API desenvolvida em .NET 8 para o gerenciamento de finalizadoras, formas de pagamento e usuários, utilizando arquitetura moderna, princípios de Clean Architecture, CQRS e MediatR.

---
<img width="1113" height="884" alt="image" src="https://github.com/user-attachments/assets/5930f50e-0e81-4011-87b8-09aee8cf4f90" />


## Visão Geral

A solução é composta por múltiplos projetos organizados por responsabilidade:

- **simple-pag**: Projeto principal da API (WebAPI).
- **simple-pag-Application**: Camada de aplicação, comandos, handlers e respostas.
- **simple-pag-Domain**: Entidades de domínio, regras de negócio e interfaces.
- **simple-pag-Infra**: Infraestrutura, repositórios, contexto de banco de dados.
- **simple-pag-Test**: Testes automatizados (unitários e de integração).

---

## Principais Funcionalidades

- Cadastro, consulta, atualização e cancelamento de finalizadoras de pagamento.
- Gerenciamento de formas de pagamento.
- Cadastro e autenticação de usuários.
- Consultas por período, mês, ano e por usuário.
- Autenticação JWT.
- Documentação automática via Swagger.
- Suporte a PostgreSQL e MongoDB.

---

## Tecnologias Utilizadas

- .NET 8 / C# 12
- MediatR (CQRS/Mediator)
- Entity Framework Core (PostgreSQL)
- MongoDB Driver
- Swagger/OpenAPI
- Moq e xUnit (testes)
- Injeção de Dependência (DI)

---

## Configuração

1. **Pré-requisitos**
   - .NET 8 SDK
   - PostgreSQL (e/ou MongoDB)
   - Variáveis de ambiente no arquivo `.env`:
     ```
     AUTHENTICATION=SuaChaveJWT
     DATABASE=host=localhost;port=5432;Database=simple;User Id=postgres;Password=123456
     ```


---

## Licença

Este projeto está sob a licença MIT.
