
# 🌿 Agri-Energy Connect

**Agri-Energy Connect** is a web-based application developed using ASP.NET Core MVC. It streamlines the management of farmer profiles and their agricultural products while distinguishing between user roles for secure and role-based access to features.

---

## 📦 Project Structure

- `Models/` – Entity classes for Users, Farmers, Products, etc.
- `Controllers/` – Handles application logic and request routing.
- `Views/` – Razor Pages for rendering user interfaces.
- `Data/` – `ApplicationDbContext` for managing database operations.
- `wwwroot/` – Static content like CSS, images, JS.

---

## 🛠️ Development Setup

Follow the steps below to set up and run the project on your local machine.

### 1. **Prerequisites**

- [Visual Studio 2022+](https://visualstudio.microsoft.com/)
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- SQL Server or LocalDB
- Git (optional, for version control)

### 2. **Configure the Database**

Update the `appsettings.json` file with your SQL Server connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=AgriEnergyConnect;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### 3. **Apply Migrations**

To create the database and apply schema changes:

```bash
dotnet ef database update
```

### 4. **Run the Application**

```bash
dotnet run
```

Or press `F5` in Visual Studio to launch the application with IIS Express.

---

## 🚀 How to Use the System

### 🔐 Authentication & Authorization

The system supports user registration and login with **role-based access**:

| Role       | Description                                                        |
|------------|--------------------------------------------------------------------|
| `Farmer`   | Can add and manage their own products.                             |
| `Employee` | Can create farmer profiles and view all products with filters.     |

---

## 🧑‍💼 Employee Functionalities

- 🔍 **Filter All Products**  
  View all products by category or date range.

- 👨‍🌾 **Create Farmer Profile**  
  - Select a user with the Farmer role from the dropdown.
  - Enter their Full Name, Email, Contact Information, and Location.
  - Save the profile to the database.

---

## 🌽 Farmer Functionalities

- ➕ **Add Product**  
  Create new products by entering details such as name, category, and production date.

- 📄 **View Products**  
  See a list of all products created by the logged-in farmer.

---

## 💡 Features

- ✅ Role-based access control (Farmer vs Employee)
- ✅ Entity Framework Core for database operations
- ✅ Bootstrap-styled, visually appealing UI
- ✅ Dynamic dropdowns and form validation
- ✅ Filtering capabilities for better product management

---

## 🧪 Testing

- Manually test features after login based on role.
- Use sample users with Farmer and Employee roles to simulate workflow.

---

## 📬 Contact

For questions or support, reach out to:

**Project Maintainer**  
📧 ethan.buck172@gmail.com  
📞 +27-23-456-7890

---

## 📃 License

This project is licensed under the MIT License.
