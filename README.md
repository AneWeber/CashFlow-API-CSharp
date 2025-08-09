# CashFlow API in C# .NET 💸

Welcome to the **CashFlow API**, a robust backend solution designed to help you meticulously track and manage your personal expenses. This project is built with C# and .NET, embracing the principles of **Domain-Driven Design (DDD)** and **REST** principles to ensure a clean, scalable, and maintainable architecture.

---

## ✨ Features

This API currently provides core functionalities for managing your financial outflow:

* **Comprehensive Expense Tracking:** Define detailed expenses including:
    * `Title`: A brief summary of the expense.
    * `Amount`: The monetary value.
    * `Description`: More details about the expense.
    * `Category`: Classification (e.g., Food, Transport, Utilities).
    * `Payment Method`: How it was paid (e.g., Credit Card, Cash, Bank Transfer).
    * `Date`: When the expense occurred.
    * `Note`: Any additional remarks.
* **Full CRUD Operations:** Seamlessly **C**reate, **R**ead, **U**pdate, and **D**elete expense records.
* **Robust Error Handling:** Integrated mechanisms to gracefully manage and communicate API errors.
* **Unit Testing:** A solid foundation of unit tests ensures reliability and helps prevent regressions.
* **Data Export:** Functionality to export expense reports to PDF and Excel formats.

---

## 🚀 Future Enhancements

This project is actively under development, with exciting features planned for future releases:

* **Database Integration:** Persistence for your expense data (e.g., SQL Server, PostgreSQL).
* **Dependency Injection:** Implementing a more flexible and testable architecture.
* **Authentication & Authorization:** Secure user access and data protection.
* **Database Migrations:** Streamlined database schema management.

---

## 🛠️ Technologies & Libraries

The CashFlow API is built using:

* **C# and .NET (Specify Version if Known, e.g., .NET 8)**
* **Domain-Driven Design (DDD)** Principles
* **Key NuGet Packages:**
    * **Bogus**: Used for generating realistic fake data for development and testing.
    * **Shouldly**: Provides highly readable and natural-sounding assertions for unit tests.
    * **FluentValidation**: Simplifies the creation of strong-typed validation rules.

---

## 🧑‍💻 Getting Started

Follow these simple steps to get the CashFlow API up and running on your local machine:

1.  **Clone the Repository:**
    ```bash
    git clone https://github.com/AneWeber/CashFlow-API-CSharp.git
    cd CashFlow-API-CSharp
    ```

2.  **Open in Visual Studio:**
    * Locate the solution file (`.sln` extension`) in the root of the cloned repository.
    * Open it with **Visual Studio** (ensure you have the correct .NET SDK installed).

3.  **Run the Application:**
    * Once the solution is loaded, press `F5` to build and run the API.
    * This will typically launch a browser showing the API's default endpoint or Swagger UI (if configured).

### Running Tests

To verify the API's functionality and explore the unit tests:

1.  While in Visual Studio, navigate to `Test` > `Test Explorer` (or `View` > `Test Explorer`).
2.  Build the solution if prompted.
3.  You should see the listed unit tests. Click `Run All Tests` to execute them.
