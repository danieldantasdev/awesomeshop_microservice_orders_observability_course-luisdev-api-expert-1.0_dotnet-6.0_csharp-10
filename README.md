# AwesomeShop.Services.Orders - Imersão .NET Expert

A arquitetura do AwesomeShop, sistema de e-commerce baseado na arquitetura de microsserviços, contém 6 microsserviços:
- Customers
- Products
- Orders
- Payments
- Notifications

## Tecnologias, práticas e arquitetura utilizadas
- ASP.NET Core com .NET 6
- Arquitetura de Microsserviços
- Princípios do Domain-Driven Design
- MongoDB
- Arquitetura Hexagonal
- Arquitetura Orientada a Eventos
- API Gateway com Kong
- Autenticação com Keycloak
- Azure Pipelines e Docker Registry
- Observabilidade com Elasticsearch, Kibana e Elastic APM

## Funcionalidades do Orders
- Cadastro
- Busca por Id
- Atualização de Status consumindo evento PaymentAccepted
