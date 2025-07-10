## 🔧 System Architecture Overview

This system manages a digital library where users can browse, check out, and return books. It consists of:

- **Frontend**  
  - Built using **React** for dynamic UI and state management.
  - Communicates with backend via RESTful APIs.

- **Backend**  
  - Developed with **.NET Framework (ASP.NET Core)**.
  - Handles business logic, user authentication, and data processing.

- **Database**  
  - Powered by **SQL Server** or **PostgreSQL** for relational data storage.
  - Stores books, users, and transaction history.

---

## 🧰 Technologies Used

| Layer      | Technology          |
|------------|---------------------|
| Frontend   | React, Axios, Bootstrap |
| Backend    | .NET Core, Entity Framework |
| Database   | SQL Server / PostgreSQL |
| Auth       | JWT (JSON Web Tokens) |
| Deployment | Docker, Azure App Service |

---

## 📦 Data Models

### Book
- `id`: UUID
- `title`: string
- `author`: string
- `genre`: string
- `availableCopies`: integer

### User
- `id`: UUID
- `name`: string
- `email`: string
- `role`: enum (student, admin)

### Transaction
- `id`: UUID
- `userId`: UUID (FK to User)
- `bookId`: UUID (FK to Book)
- `type`: enum (checkout, return)
- `timestamp`: datetime

---

## 🌐 API Endpoints

### 📖 Book Checkout
```http
POST /api/transactions/checkout
Body: {
  "userId": "...",
  "bookId": "..."
}
Response: 200 OK or error