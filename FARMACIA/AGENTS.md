# AGENTS.md

## Proyecto

Sistema de Inventario para Farmacia desarrollado en ASP.NET Core Web API (.NET 8).

## Arquitectura Aplicada

* Arquitectura Hexagonal
* Domain Driven Design (DDD)
* Principios SOLID
* Repository Pattern
* Dependency Injection
* JWT Authentication

## Herramienta de IA Utilizada

ChatGPT (OpenAI)

## Reglas Utilizadas Durante el Desarrollo

1. Mantener separación entre Domain, Application e Infrastructure.
2. Aplicar Repository Pattern para el acceso a datos.
3. Utilizar Dependency Injection para reducir el acoplamiento.
4. Implementar autenticación JWT.
5. Utilizar Entity Framework Core con MySQL.
6. Mantener las entidades de dominio independientes de la infraestructura.

## Prompts Utilizados

### Arquitectura

* Crear una arquitectura hexagonal para una API de farmacia en .NET 8.
* Separar el proyecto en Domain, Application e Infrastructure.

### Base de Datos

* Crear entidades y repositorios para medicamentos.
* Configurar Entity Framework Core con MySQL.

### Seguridad

* Implementar autenticación JWT en ASP.NET Core.
* Configurar validación de tokens JWT.

### DDD

* Crear un Aggregate para Medicamento.
* Crear un Value Object para Precio.
* Crear un Domain Event para StockAgotado.

### Docker

* Crear Dockerfile para ASP.NET Core.
* Configurar Docker Compose para la API.

## Resultado

La IA fue utilizada como apoyo para diseño arquitectónico, generación de código base, configuración de infraestructura, resolución de errores y validación de buenas prácticas de desarrollo.
