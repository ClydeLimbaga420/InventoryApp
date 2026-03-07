# InventoryPro – ASP.NET Core MVC Inventory Management System

## Tech Stack
- ASP.NET Core 8 MVC
- Entity Framework Core 8 + SQL Server (LocalDB)
- ASP.NET Core Identity (Individual Authentication)
- Bootstrap 5.3 + Bootstrap Icons
- Inter font (Google Fonts)

---

## Setup Instructions

### Prerequisites
- .NET 8 SDK
- SQL Server LocalDB (comes with Visual Studio) **or** SQL Server Express
- Visual Studio 2022 **or** VS Code + C# extension

---

### Step 1 – Clone / Open Project
Open the solution folder in Visual Studio or VS Code.

### Step 2 – Update Connection String
Edit `appsettings.json` if you need a different database server:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=InventoryAppDb;Trusted_Connection=True;"
}
```

### Step 3 – Apply Migrations
Open **Package Manager Console** (Visual Studio) or a terminal in the project folder:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Step 4 – Run the App
```bash
dotnet run
```
Or press **F5** in Visual Studio.

---

## Seeded Accounts

The app automatically seeds these accounts on first run:

| Role  | Email                 | Password   |
|-------|-----------------------|------------|
| Admin | admin@inventory.com   | Admin@123  |
| User  | user@inventory.com    | User@123   |

---

## Features by Part

| Part | Feature                          | Status |
|------|----------------------------------|--------|
| 1    | Auth (Login / Register)          | ✅     |
| 2    | Product CRUD + Validation        | ✅     |
| 3    | Bootstrap Table UI               | ✅     |
| 4    | Search, Filter, Sort             | ✅     |
| 5    | Dashboard (cards + latest table) | ✅     |
| 6    | Role-Based UI (Admin / User)     | ✅     |
| 7    | Responsive, clean UI/UX          | ✅     |

---

## Project Structure

```
InventoryApp/
├── Controllers/
│   ├── HomeController.cs
│   ├── DashboardController.cs
│   └── ProductsController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Models/
│   ├── ApplicationUser.cs
│   ├── Product.cs
│   └── DashboardViewModel.cs
├── Views/
│   ├── Dashboard/Index.cshtml
│   ├── Products/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── Delete.cshtml
│   └── Shared/_Layout.cshtml
├── wwwroot/
│   ├── css/site.css
│   └── js/site.js
├── Program.cs
└── appsettings.json
```

---

## Role-Based Access

- **Admin**: Full CRUD (Create, Edit, Delete, View)
- **User**: View-only (no Add/Edit/Delete buttons shown)

Roles are enforced both in the controller (`[Authorize(Roles = "Admin")]`) and in the views (buttons hidden via `@if (User.IsInRole("Admin"))`).
