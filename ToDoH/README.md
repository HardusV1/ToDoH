
# AngularJS + ASP.NET Core 8 MVC Todo App

A lightweight Todo application built using **AngularJS** on the frontend and **ASP.NET Core 8 MVC** on the backend, with **Entity Framework Core** and **SQL Server** for data persistence.

---

## 🚀 Features

- Add new todo items
- Toggle completion status (with persistence)
- Delete individual todo items
- View completed vs. remaining counts
- Responsive Bootstrap UI
- REST-style backend with SQL Server
- Authentication support with ASP.NET Identity

---

## 📁 Project Structure



ToDoH/
├── wwwroot/
│   └── angularjs-todo-test-main/
│       ├── app.js
│       ├── index.html
│       └── styles.css
│   ├── css/
│   ├── js/
│   ├── lib/
│   └── favicon.ico
├── Areas/
├── Controllers/
│   ├── HomeController.cs
│   └── TodosController.cs
├── Data/
│   ├── Migrations/
│   └── ApplicationDbContext.cs
├── DTO/
│   └── TodoCreateDto.cs
├── Models/
│   ├── Todos/
│   │   └── TodoItemModel.cs
│   └── ErrorViewModel.cs
├── Views/
│   ├── Home/
│   ├── Shared/
│   └── Todos/
│       ├── Index.cshtml
│       ├── \_ViewImports.cshtml
│       └── \_ViewStart.cshtml
├── appsettings.json
├── Program.cs
├── README.md
└── ToDoH.bak



---

## 🛠 Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Microsoft SQL Server
- [EF Core CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
- AngularJS (served from `wwwroot`)
- SQL Server Management Studio (optional)

---

## ⚙️ Setup Instructions

### 1. Clone the Repository

bash
git clone https://github.com/HardusV1/ToDoH
cd todoapp


### 2. Update Database Connection

Edit `appsettings.json`:

json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TodoDB;User Id=your_user;Password=your_password;TrustServerCertificate=True;"
}


> ✅ For Windows Authentication:

json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TodoDB;Trusted_Connection=True;TrustServerCertificate=True;"
}


### 3. Install EF Core SQL Server Provider (if not already added)

bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer


### 4. Apply Migrations
bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add Init
dotnet ef database update

### 5. Run the App

bash
dotnet run


Navigate to:

* Razor view: `https://localhost:5001/Todos/Index`
* AngularJS frontend: `https://localhost:5001/angularjs-todo-test-main/index.html`

---

## 🧪 API Endpoints

| Method | Endpoint                                       | Description                        |                                 |
| ------ | ---------------------------------------------- | ---------------------------------- | ------------------------------- |
| GET    | `/Todos/GetTodos`                              | Get all todos                      |                                 |
| POST   | `/Todos/AddTodo`                               | Add a new todo (from JSON body)    |                                 |
| POST   | `/Todos/DeleteTodo?id={id}`                    | Delete a todo by ID                |                                 |
| POST   | `/Todos/ToggleCompleted?id={id}`               | Toggle completion status of a todo |                                 |
| POST   | `/Todos/MarkIncomplete?id={id}`                | Force set todo to incomplete       |                                 |
| POST   | \`/Todos/SetCompletion?id={id}\&completed=true | false\`                            | Set completed status explicitly |

---

## 🔐 Authentication

The backend uses ASP.NET Core Identity. All todo endpoints are protected with `[Authorize]`, so users must be logged in to manage their own items.

---

## 💡 Tech Stack

* **Frontend**: AngularJS, Bootstrap 5, HTML/CSS
* **Backend**: ASP.NET Core 8 MVC, Entity Framework Core
* **Database**: Microsoft SQL Server
* **Auth**: ASP.NET Identity

---

## 📄 License

MIT License — use freely and modify as needed.

---
