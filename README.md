# Ambev Developer Evaluation

This project is a .NET 8 solution designed for evaluating developer skills through a realistic, modular, 
and testable sales management system. It demonstrates best practices in architecture, security, validation, 
and API design.

## Features

- **User Management**: Create and retrieve users with secure password hashing (BCrypt).
- **Authentication**: JWT-based authentication for secure API access.
- **Sales Management**: Create, retrieve, and cancel sales, including sale items.
- **Validation**: Robust request validation using FluentValidation.
- **Domain Events**: Event-driven architecture for user registration and sale cancellation.
- **Dependency Injection**: Modular IoC setup for application, infrastructure, and Web API layers.
- **Persistence**: Entity Framework Core with code-first migrations.
- **Testing**: Unit tests for domain entities and business logic.
- **API Documentation**: (Add Swagger/OpenAPI details if available.)

## Project Structure

- `src/Ambev.DeveloperEvaluation.WebApi`: ASP.NET Core Web API entry point and controllers.
- `src/Ambev.DeveloperEvaluation.Application`: Application layer with business logic and handlers.
- `src/Ambev.DeveloperEvaluation.Domain`: Domain entities, events, and repository interfaces.
- `src/Ambev.DeveloperEvaluation.ORM`: Entity Framework Core mappings, migrations, and repositories.
- `src/Ambev.DeveloperEvaluation.IoC`: Dependency injection and module initializers.
- `src/Ambev.DeveloperEvaluation.Common`: Shared utilities (security, validation).
- `tests/Ambev.DeveloperEvaluation.Unit`: Unit tests for domain and application logic.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/) (for running database via `docker-compose`)
- (Optional) SQL Server or PostgreSQL, depending on ORM configuration

### Setup

1. **Clone the repository:**

2. **Start the database (if using Docker):**

docker-compose up -d
docker exec -it ambev_developer_evaluation_database psql -U developer -d developer_evaluation

3. **Apply database migrations:**

dotnet ef database update --project src/Ambev.DeveloperEvaluation.ORM --startup-project src/Ambev.DeveloperEvaluation.WebApi

4. **Run the Web API:**

dotnet run --project src/Ambev.DeveloperEvaluation.WebApi

5. **Run tests:**

dotnet test --project tests/Ambev.DeveloperEvaluation.Unit