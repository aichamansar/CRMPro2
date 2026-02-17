🚀 CRMPro - Enterprise Modular CRM
A high-performance, scalable CRM backend built with .NET 8 following Clean Architecture and DDD (Domain-Driven Design) principles.
🏗 Architecture Overview
This project follows the Dependency Rule, where the inner layers (Domain) have no knowledge of the outer layers (Infrastructure/API).
CRM.Domain: Core entities (Contacts, Accounts, Leads, Deals), Enums, and Repository Interfaces. No external dependencies.
CRM.Application: Orchestration layer using MediatR for Use Cases, FluentValidation for business rules, and AutoMapper for DTOs.
CRM.Infrastructure: Implementation of data persistence using EF Core (SQL Server) and external integrations.
CRM.WebAPI: The entry point. Thin controllers, JWT Authentication, and Global Exception Handling.

🛠 Tech Stack
Framework: .NET 8 Web API
Database: SQL Server with EF Core
Patterns: CQRS (with MediatR), Repository Pattern, Unit of Work
Validation: FluentValidation
Mapping: AutoMapper
Documentation: Swagger / OpenAPI


📂 Project Structure
text
src/
├── CRM.Domain/         # Business Entities & Core Logic
├── CRM.Application/    # Use Cases (Commands & Queries)
├── CRM.Infrastructure/ # Database & External Services
└── CRM.WebAPI/         # API Endpoints & Middleware


🚀 Getting Started
Clone the repository: git clone https://github.com
Update Connection String: Modify appsettings.json in the CRM.WebAPI project.
Apply Migrations:
bash
dotnet ef database update --project src/CRM.Infrastructure --startup-project src/CRM.WebAPI



Run the App: Press F5 in Visual Studio or run dotnet run --project src/CRM.WebAPI.
🧪 Key Features Implemented
Modular Structure: Separate folders for Accounts, Contacts, and Leads.
Global Error Handling: Unified JSON responses for all API errors.
Fluent Validation: Automatic validation of emails, phone numbers, and deal amounts.
Dashboards: Optimized queries for the "Total/Active/Prospect" metrics.


