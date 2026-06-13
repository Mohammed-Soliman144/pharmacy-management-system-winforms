# 💊 Pharmacy Management System (Enterprise Desktop Application)

A **95% complete enterprise-grade Pharmacy Management System** built using **C#, .NET, and SQL Server**, designed to handle real-world pharmacy operations including inventory, billing, reporting, and advanced database-driven workflows.

---

## 🚀 Overview

This system simulates a **real pharmacy business environment** with a strong focus on:

* Complex inventory management (multi-units, pricing tiers)
* Sales & purchase lifecycle
* Customer account tracking
* POS (Point of Sale) system
* Advanced reporting using Crystal Reports
* Database-centric architecture using SQL Server & Stored Procedures

> ⚡ This project represents a **transition step toward Full Stack .NET (ASP.NET Core + React)**

---

## 🧠 Core Features

### 🛒 Sales & POS System

* Create sales invoices
* Handle returns (ReSale / ReBuy)
* Multi-unit pricing (Large / Medium / Small)
* Discount handling with limits

---

### 📦 Inventory System (Advanced)

* Multi-unit item system:

  * Large / Medium / Small units
  * Separate buy/sell prices per unit
* Stock tracking & quantity control
* Demand limit alerts
* Expiry tracking

---

### 👥 Customer & Accounts

* Customer profiles
* Transaction tracking
* Account balance management

---

### 🏢 Business Modules

* Branch management
* Company & supplier management
* Item classification system

---

## 🧬 Advanced Database Design

The system uses a **highly normalized and relational database structure**:

### 🔗 Core Relationships

Each item is linked to:

* Dosage Form
* Generic Name
* Class of Action
* Scientific Group
* Company
* Storage Location (Place)
* Units

---

### 🧾 Item Entity (Complex Business Model)

The `Items` table demonstrates advanced database design:

* Multiple barcodes support
* Multi-unit hierarchy (Large → Medium → Small)
* Separate pricing per unit
* Quantity tracking per unit
* Flags for:

  * Narcotic
  * Refrigerated
  * Imported / Local
  * Expiry tracking

---

### 🧠 Example Fields

* `ItemLargeUnitSalePrice`
* `ItemMediumQuantity`
* `ItemSmallUnitBuyPrice`
* `ItemDemandLimit`
* `ItemMaxDiscount`
* `ItemExpiry`
* `ItemNarcotic`

👉 This reflects **real-world pharmacy complexity**, not a simple CRUD system.

---

## 📊 Reporting System (Crystal Reports)

The system includes a dedicated reporting module:

### 📁 RPT/

Contains:

* Crystal Report files (.rpt)

### 📌 Features:

* Sales invoices printing
* Purchase reports
* Inventory reports
* Customer transaction reports

### 🎯 Benefits:

* Professional printable documents
* Separation of reporting logic
* Business-ready reporting system

---

## 🏗️ Architecture

The project follows a **Layered Architecture**:

* **DAL (Data Access Layer)** → SQL + Stored Procedures
* **BAL (Business Logic Layer)** → Core business rules
* **PAL (Presentation Layer)** → WinForms UI
* **RPT (Reporting Layer)** → Crystal Reports
* **Database Layer** → SQL Server

---

## 🖥️ Application Type

* Desktop Application (Windows Forms)
* Built using .NET Framework
* Designed for business environments (pharmacies, stores)

---

## ⚙️ Technologies Used

* C#
* .NET Framework
* SQL Server
* ADO.NET
* Stored Procedures
* Crystal Reports

---

## 📂 Project Structure

```bash
PharmacySystem/
│
├── DAL/                 # Data access
├── BAL/                 # Business logic
├── PAL/                 # UI (WinForms)
├── RPT/                 # Crystal Reports
├── RSC/                 # Resources
├── database/            # SQL scripts
└── App.config           # Configuration
```

---

## 🛠️ Database Setup

1. Open SQL Server
2. Run scripts:

```bash
/database/tables
/database/stored-procedures
/database/seed
```

3. Update connection string in `App.config`

---

## 🔐 Security Notes

* No sensitive data included
* Configurable connection strings
* No database backups uploaded

---

## 📈 Project Status

✅ **95% Completed**

Remaining improvements:

* UI refinements
* Performance optimization
* Migration to Web Architecture

---

## 🚀 Future Roadmap (Full Stack Evolution)

This project is planned to evolve into:

* ASP.NET Core Web API
* React / Next.js Frontend
* JWT Authentication
* Cloud Deployment (Azure)
* Replace Crystal Reports with modern dashboards

---

## 🎯 Learning Outcomes

Through this project, I gained:

* Deep understanding of **real-world database design**
* Experience building **enterprise desktop systems**
* Strong knowledge of **stored procedures & SQL optimization**
* Ability to implement **layered architecture**
* Understanding of **business workflows (POS, inventory, accounting)**

---

## 🤝 Contributing

Feel free to fork and improve the system.

---

## 📬 Contact

* GitHub: [your-profile]
* LinkedIn: [your-link]

---

## ⭐ Final Note

This is not a simple CRUD project.

It is a **business-oriented system** that demonstrates:

* Real-world complexity
* Backend engineering thinking
* Scalable architecture design

👉 A solid foundation for transitioning into **Full Stack .NET Development**
