# Municipality Management System

## 📌 Overview
The **Municipality Management System** is a full-stack web application built with **ASP.NET Core MVC**.  
It provides municipalities with tools to manage **citizen records, service requests, staff information, and citizen-submitted reports** in a structured and efficient way.  

This project demonstrates **enterprise-grade development practices**, including MVC architecture, Entity Framework Core with migrations, input validation, and clean separation of concerns.

---

## 🚀 Key Features
- 👤 **Citizen Management** – Register, update, and maintain citizen profiles.  
- 📝 **Service Requests** – Track and manage requests with status updates.  
- 👨‍💼 **Staff Management** – Organize and administer municipal staff records.  
- 📑 **Reports Module** – Citizens can submit reports; staff can review and update statuses.  
- ✅ **Validation & Error Handling** – Ensures data integrity and improves user experience.  

---

## 🛠️ Tech Stack
- **Backend:** ASP.NET Core MVC 7.0 (C#)  
- **Database:** SQL Server with Entity Framework Core (Code-First Migrations)  
- **Frontend:** Razor Views, Bootstrap, JavaScript, CSS  
- **IDE:** Microsoft Visual Studio 2022  

---

## 📂 Project Structure

MunicipalityManagementSystem.sln
└── MunicipalityManagementSystem/
├── Controllers/ # Application logic
├── Models/ # Entity classes & DbContext
├── Views/ # Razor Pages (UI)
├── Migrations/ # Database migrations
├── wwwroot/ # Static assets (CSS, JS, images)
└── Program.cs # Application entry point
