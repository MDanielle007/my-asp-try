# MyApp (.NET 9 + Entity Framework Core + Tailwind CSS)

This is a web application built with **ASP.NET Core MVC**, **Entity Framework Core**, and **Tailwind CSS**. It uses a **local development database** and follows best practices for environment configuration and Git management.

---

## 📁 Folder Structure

```
/MyApp
├── Controllers/
├── Data/
├── Migrations/
├── Models/
├── Views/
├── wwwroot/
├── appsettings.json
├── Program.cs
├── package.json (for Tailwind)
├── tailwind.config.js

```

---

## 🧑‍💻 Development Setup

### 1. 🔧 Clone and Initialize Project

```bash
git clone https://github.com/MDanielle007/my-asp-try.git
cd my-asp-try
```

---

### 2. 🛠️ Configure Connection String

The `appsettings.Development.json` is used for local development and is ignored from Git tracking.
Create your own `appsettings.Development.json` manually in the root directory:

```json
{
    "ConnectionStrings": {
        "DefaultConnectionString": "your-localdb-connection-string"
    }
}
```

> Replace `your-localdb-connection-string` with your actual connection string like:

```text
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=myapp_db;Integrated Security=True
```

---

### 3. 🧬 Run Entity Framework Core Migrations

In **Visual Studio**, open the **Package Manager Console** and run:

```powershell
EntityFrameworkCore\Update-Database
```

> If you’re using dotnet CLI instead:

```bash
dotnet ef database update
```

---

### 4. 🎨 Tailwind CSS Setup

Install Tailwind CSS dependencies (from the `/MyApp` directory with `package.json`):

```bash
cd MyApp
npm install
npx tailwindcss -i ./wwwroot/css/site.css -o ./wwwroot/css/output.css --watch
```

> Ensure `site.css` is your Tailwind input file, and `output.css` is used in your layout.

---

### 5. ▶️ Run the App

You can run the application in two ways:

#### ✅ Option 1: Using .NET CLI

```bash
dotnet run
```

#### ✅ Option 2: Using Visual Studio

-   Open the project in Visual Studio.
-   Click **"Run"** or press **F5**.

Once running, navigate to:

📍 [https://localhost:7145/](https://localhost:7145/)

## 🛡️ Git Best Practices

-   `appsettings.Development.json` is ignored via `.gitignore`.
-   Do **not** commit secrets or connection strings.
-   Reset history by deleting `.git` folder (if needed):

```powershell
Remove-Item -Recurse -Force .git
git init
git add .
git commit -m "Initial commit"
```

---

## 🧩 Technologies Used

-   ASP.NET Core MVC
-   Entity Framework Core
-   Tailwind CSS
-   SQL Server LocalDB
-   Visual Studio / .NET CLI
-   Node.js + npm

---

## 🤝 Contributions

Feel free to fork and contribute via pull requests!

---

## 📄 License

This project is under the [MIT License](LICENSE).
