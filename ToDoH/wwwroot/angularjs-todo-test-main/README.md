# AngularJS + .NET 8 MVC Todo App

This is a Todo application using **AngularJS** for the frontend and **ASP.NET Core 8 MVC** with **Microsoft SQL Server** for the backend.

---

## 🚀 Features

* Add, remove, and view todo items
* Track completed and remaining items
* Backend REST API with MSSQL persistence
* Responsive UI styled with Bootstrap

---

## 📁 Project Structure

```
TodoApp/
├── Controllers/
│   └── TodosController.cs
├── Data/
│   └── TodoContext.cs
├── Models/
│   └── Todo.cs
├── wwwroot/
│   ├── index.html
│   ├── app.js
│   └── styles.css
├── Program.cs
├── appsettings.json
└── README.md
```

---

## 🛠 Requirements

* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* Microsoft SQL Server
* [EF Core CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
* SQL Server Management Studio (optional)

---

## ⚙️ Setup Instructions

### 1. Clone the Repo

```bash
git clone https://github.com/your-username/todoapp.git
cd todoapp
```

### 2. Update MSSQL Connection

Edit `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TodoDB;User Id=your_user;Password=your_password;TrustServerCertificate=True;"
}
```

> For Windows Authentication, use:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TodoDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Add EF Core SQL Server Provider (if not added yet)

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

### 4. Run EF Core Migrations

```bash
dotnet tool install --global dotnet-ef

dotnet ef migrations add Init

dotnet ef database update
```

### 5. Run the App

```bash
dotnet run
```

Open in browser: `https://localhost:5001/`

---

## 🧪 API Endpoints

| Method | Endpoint          | Description       |
| ------ | ----------------- | ----------------- |
| GET    | `/api/todos`      | Get all todos     |
| POST   | `/api/todos`      | Add new todo      |
| DELETE | `/api/todos/{id}` | Delete todo by ID |

---

## 📄 License

MIT License. Use it freely.

---

## 🤝 Acknowledgements

* [AngularJS](https://angularjs.org/)
* [ASP.NET Core 8](https://learn.microsoft.com/en-us/aspnet/core)
* [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer)
* [Bootstrap](https://getbootstrap.com/)