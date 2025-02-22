# 📌 DTR Web API (Clean Architecture)  

🚀 A **.NET Web API** project implementing **Clean Architecture** with **CQRS, MediatR, and EF Core**.  

## 🏛 Architecture Overview  
This project follows a **4-layered Clean Architecture**:  

```
DTRWebAPI
│── Domain          # Core Business Logic
│   ├── Entities    # Employee Entity
│   ├── Interfaces  # Repository Interfaces
│
│── Application     # Business Use Cases (CQRS)
│   ├── Commands    # Commands for modifying data
│   ├── Queries     # Queries for retrieving data
│   ├── Handlers    # MediatR Handlers for commands & queries
│
│── Infrastructure  # Data Access Layer
│   ├── Data        # AppDbContext (EF Core)
│   ├── Repositories # Implements Repositories
│   ├── Migrations  # EF Core Migrations
│
│── WebAPI         # Presentation Layer (Controllers)
│   ├── Controllers # API Endpoints (EmployeesController.cs)
│
└── README.md
```

## 🛠 Technologies & Packages  
### ✅ **Backend**  
- **.NET Web API** (ASP.NET Core)  
- **Entity Framework Core** (EF Core)  
- **SQL Server**  

### 📦 **NuGet Packages**  
| Layer          | Package Name                                      | Purpose |
|---------------|------------------------------------------------|---------|
| **Application**   | `MediatR`  | Implements CQRS Pattern |
| **Application, Infrastructure, Domain** | `Microsoft.Extensions.DependencyInjection.Abstractions` | Dependency Injection |
| **Infrastructure** | `Microsoft.EntityFrameworkCore.SqlServer` | EF Core SQL Server Provider |
| **Infrastructure** | `Microsoft.EntityFrameworkCore.Tools` | Migration & Scaffolding |
| **WebAPI** | `Microsoft.EntityFrameworkCore.Design` | Required for Migrations |

## 🏗 Setup & Installation  
1️⃣ Clone this repository:  
```sh
git clone [https://github.com/yourusername/DTRWebAPI.git](https://github.com/SeeFlushFlush64/DTRWebAPICleanArchitecture.git)
```
2️⃣ Navigate to the project directory:  
```sh
cd DTRWebAPI
```
3️⃣ Install dependencies:  
```sh
dotnet restore
```
4️⃣ Apply database migrations:  
```sh
dotnet ef database update
```
5️⃣ Run the application:  
```sh
dotnet run
```
6️⃣ API is now running at: `https://localhost:5001` 🎉  

## 🔥 Features  
✅ **CQRS with MediatR**  
✅ **Entity Framework Core (Code First)**  
✅ **Dependency Injection**  
✅ **Repository & Unit of Work Pattern**  
✅ **Migrations using EF Core**  
✅ **Data Transfer Objects (DTOs)**
✅ **AutoMapper for DTO Mapping**

## 📖 API Endpoints  
| Method | Endpoint | Description |
|--------|---------|------------|
| `GET` | `/api/employees` | Get all employees |
| `GET` | `/api/employees/{id}` | Get employee by ID |
| `POST` | `/api/employees` | Add a new employee |
| `PUT` | `/api/employees/{id}` | Update an existing employee |
| `DELETE` | `/api/employees/{id}` | Delete an employee |

## 🎯 Future Improvements  
- 🔹 **Unit Tests with xUnit**  
- 🔹 **FluentValidation for Request Validation**  
- 🔹 **JWT Authentication**  
- 🔹 **Docker Support**  

## 📝 License  
This project is **MIT Licensed**. Feel free to use and contribute! 🚀  
