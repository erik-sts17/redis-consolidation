# Redis Cache Consolidation

Projeto de consolidação da **camada de cache utilizando Redis**, desenvolvido em **.NET 8**, com foco em arquitetura, organização e boas práticas no uso de **cache distribuído**.

A aplicação consome dados de uma API externa (**PokeAPI**) e utiliza o Redis como camada intermediária para otimizar performance, reduzir chamadas externas e controlar expiração de dados.

## 📌 Objetivo do Projeto

Este projeto tem como objetivo consolidar os conceitos de **cache distribuído com Redis**, demonstrando:

- Uso do Redis como camada de cache
- Estratégias de cache-first
- Controle de expiração (TTL)
- Isolamento da camada de cache da lógica de negócio
- Integração com APIs externas

O foco principal é **arquitetura e uso correto do cache**, não a complexidade do domínio.

## 🧠 Conceitos Aplicados

- Cache distribuído com Redis
- Redução de chamadas a APIs externas
- Expiração e invalidação de cache
- Separação de responsabilidades

## 🏗️ Arquitetura

O projeto segue uma **arquitetura em camadas**, dividida da seguinte forma:

### 🔹 API
- Exposição dos endpoints HTTP
- Responsável apenas por:
  - Receber requisições
  - Delegar chamadas à camada de negócio
  - Retornar respostas

### 🔹 Business
- Contém as **regras de negócio**
- Orquestra:
  - Verificação de cache
  - Decisão entre buscar no Redis ou na API externa
- Não conhece detalhes de infraestrutura

### 🔹 Data
- Responsável por acesso a dados e integrações
- Inclui:
  - Implementação do cache Redis
  - Consumo da PokeAPI

## 🛠️ Bibliotecas Utilizadas

- **Redis**
- **StackExchange.Redis**
- **Refit** (consumo da API externa)

