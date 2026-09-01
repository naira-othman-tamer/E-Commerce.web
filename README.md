# 🛒 E-Commerce Web API

A modern **E-Commerce Web API** built with **ASP.NET Core 10** and designed with a clean, layered architecture.

The project provides the backend foundation for an online shopping platform, including product catalog management, shopping basket operations, order processing, user authentication, authorization, pagination, filtering, sorting, and centralized error handling.

The application is currently under development, with **payment integration, caching, and Angular frontend integration** planned as upcoming features.

---

## 🚀 Features

### 🔐 Authentication & Authorization

* User registration and login
* JWT-based authentication
* Role-based authorization
* ASP.NET Core Identity
* Secure password management

### 📦 Product Management

* Browse products
* Retrieve product details
* Product brands and types
* Product filtering
* Product searching
* Sorting
* Pagination
* Eager loading of related entities

### 🛒 Shopping Basket

* Create and manage user baskets
* Add products to the basket
* Update product quantities
* Remove products from the basket
* Retrieve the current user's basket

### 📋 Orders

* Create orders from the user's basket
* Manage shipping information
* Retrieve order details
* Retrieve user orders
* Order processing workflow

### 🧩 Specification Pattern

The project uses the **Specification Pattern** to encapsulate query logic and keep data-access concerns separated from business logic.

Specifications support:

* Filtering
* Eager loading
* Sorting
* Pagination

### ⚠️ Error Handling

* Centralized exception handling
* Custom exception middleware
* Consistent API error responses

### 📄 Pagination & Querying

Reusable pagination and query models are provided through the shared layer to support:

* Page size
* Page index
* Searching
* Filtering
* Sorting

### 📚 API Documentation

The API provides development-time API documentation using:

* OpenAPI
* Swagger
* Scalar

---

## 🏗️ Architecture

The project follows a **layered architecture** with clear separation of responsibilities.

```text
E-Commerce.web
│
├── Core
│   ├── Domain
│   │   ├── Contracts
│   │   ├── Exceptions
│   │   └── Models
│   │
│   ├── ServiceAbstraction
│   │   ├── IAuthenticationService
│   │   ├── IBasketService
│   │   ├── IOrderService
│   │   ├── IProductService
│   │   └── IServiceManager
│   │
│   └── ServiceImplementation
│       ├── Services
│       ├── Specifications
│       ├── Mapping
│       └── Configurations
│
├── Infrastructure
│   │
│   ├── Persistence
│   │   ├── Configurations
│   │   ├── Data
│   │   ├── Identity
│   │   ├── Repositories
│   │   └── Helpers
│   │
│   └── Presentation
│       └── Controllers
│
├── E-Commerce.Web
│   ├── CustomMiddlewares
│   ├── Extensions
│   ├── Factories
│   ├── wwwroot
│   └── Program.cs
│
└── Shared
    ├── DTOs
    ├── Enums
    ├── ErrorModels
    ├── Pagination
    └── Query Parameters
```

### Core

Contains the application's business-related abstractions and domain models.

* **Domain** contains entities, contracts, and domain exceptions.
* **ServiceAbstraction** contains service interfaces.
* **ServiceImplementation** contains the implementation of application services and specification logic.

### Infrastructure

Responsible for external concerns such as persistence and presentation.

* **Persistence** handles Entity Framework Core, repositories, database configuration, and Identity.
* **Presentation** contains the API controllers.

### E-Commerce.Web

The application's entry point and API host.

It contains:

* Application configuration
* Dependency injection extensions
* Middleware configuration
* Exception handling
* Authentication and authorization setup
* API pipeline configuration

### Shared

Contains reusable models shared across different layers, including:

* DTOs
* Enums
* Error models
* Pagination models
* Query parameters

---

## 🛠️ Technologies

### Backend

* **C#**
* **.NET 10**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **SQL Server**
* **ASP.NET Core Identity**
* **JWT Authentication**
* **AutoMapper**

### Architecture & Design Patterns

* Layered Architecture
* Repository Pattern
* Unit of Work Pattern
* Specification Pattern
* Dependency Injection
* Separation of Concerns
* SOLID Principles

### API & Documentation

* RESTful APIs
* OpenAPI
* Swagger
* Scalar

---

## 🔎 Querying & Specifications

The project uses a reusable specification abstraction to keep query-related logic out of repositories and services.

A specification can define:

```text
Criteria
    ↓
Includes
    ↓
Ordering
    ↓
Pagination
```

This makes complex queries reusable and keeps the data-access layer clean.

---

## 🔐 Security

The application uses:

* JWT Bearer Authentication
* ASP.NET Core Identity
* Role-based authorization
* Secure authentication middleware
* Centralized exception handling

Sensitive configuration such as JWT secrets and database connection strings should be provided through configuration/environment variables rather than committed to source control.

---

## ⚙️ Getting Started

### Prerequisites

Make sure you have the following installed:

* [.NET 10 SDK](https://dotnet.microsoft.com/)
* SQL Server
* Visual Studio 2026 or another compatible .NET IDE
* Git

### Clone the Repository

```bash
git clone https://github.com/naira-othman-tamer/E-Commerce.web.git
cd E-Commerce.web
```

### Configure the Application

Update your local configuration with the required:

* SQL Server connection string
* JWT configuration
* Identity configuration

Do not commit secrets or production credentials to the repository.

### Apply Database Migrations

From the project containing the `DbContext`, run:

```bash
dotnet ef database update
```

### Run the Application

```bash
dotnet run --project E-Commerce.Web
```

When running in development mode, the API documentation can be accessed through the configured OpenAPI/Swagger/Scalar endpoints.

---

## 🧪 Development Status

This project is actively under development.

### ✅ Implemented

* [x] Product catalog
* [x] Product filtering and searching
* [x] Sorting
* [x] Pagination
* [x] Specification Pattern
* [x] Repository Pattern
* [x] Unit of Work
* [x] Authentication & Authorization
* [x] JWT Authentication
* [x] ASP.NET Core Identity
* [x] Shopping Basket
* [x] Order Management
* [x] Global Exception Handling
* [x] API documentation

### 🚧 In Progress

* [ ] Payment Integration
* [ ] Caching
* [ ] Angular Frontend Integration

---

## 🎯 Future Improvements

Planned improvements include:

* Payment gateway integration
* Distributed/in-memory caching
* Angular frontend
* Full frontend-backend integration
* Additional automated tests
* Production deployment

---

## 👩‍💻 Author

**Naira Othman**

Backend .NET Developer

GitHub: [@naira-othman-tamer](https://github.com/naira-othman-tamer)
