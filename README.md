# 📦 Warehouse Management System (WMS)

![.NET](https://img.shields.io/badge/.NET-6.0-blueviolet?style=for-the-badge&logo=dotnet)
![EF Core](https://img.shields.io/badge/EF_Core-Entity_Framework-green?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/SQL_Server-2019-red?style=for-the-badge&logo=microsoft-sql-server)
![Architecture](https://img.shields.io/badge/Architecture-Clean_Architecture-orange?style=for-the-badge)

یک سامانه قدرتمند و مدرن برای مدیریت هوشمند موجودی انبار، کنترل اسناد ورود و خروج و گزارش‌گیری دقیق کاردکس کالا.

---

## 🏗 معماری و ویژگی‌های فنی (Technical Excellence)

این پروژه با تمرکز بر **قابلیت نگهداری (Maintainability)** و **امنیت داده‌ها** طراحی شده است:

*   **📐 Clean Architecture:** جداسازی کامل لایه‌ها (Domain, Application, Infrastructure, API) برای کاهش وابستگی‌ها و افزایش تست‌پذیری.
*   **🛡 Data Integrity (Unit of Work):** استفاده از الگوی `UnitOfWork` و مدیریت `Transactions` برای تضمین اینکه عملیات‌های چندمرحله‌ای (مثل ثبت سند و به‌روزرسانی موجودی) یا به صورت کامل انجام شوند یا اصلاً انجام نشوند.
*   **⚡ Concurrency Control:** پیاده‌سازی استراتژی **Optimistic Concurrency** با استفاده از `RowVersion` جهت جلوگیری از Race Condition و از دست رفتن داده‌ها هنگام دسترسی همزمان کاربران.
*   **🔍 Advanced Filtering:** موتور فیلترینگ پویا برای جستجو در محصولات، اسناد و انبارها.

---

## 🛠 پیش‌نیازها (Prerequisites)

برای اجرای روان پروژه، موارد زیر را نصب داشته باشید:
- [**.NET 6.0 SDK**](https://dotnet.microsoft.com/download)
- [**SQL Server 2019**](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

---

## 🚀 راهنمای راه‌اندازی (Setup Guide)

### ۱. تنظیم پایگاه داده
فایل `appsettings.json` را باز کرده و رشته اتصال (Connection String) را مطابق با تنظیمات سیستم خود تغییر دهید:
```json
{
  "ConnectionStrings": {
"defaultConnection": "Server=.\\MSSQLSERVER2019;Database=WarehouseManagementDb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"
  }
}


##  راهنمای اجرا
 پروژه و تنظیمات رو کامل انجام داده و پروژه را اجرا کنید دیتابیس  پروژه به صورت اتومات ایجاد می شود.

 کاربر ادمین جهت لاگین :
 Username = AdminUser
PasswordHash = 123456
Phone = "09121234567"

کاربر اوپراتور جهت انجام عملیات ثبت سند :
Username = OperatorUser2
PasswordHash = 123456
Phone = "09139876543"

## محدودیت های پروژه
کاربران ثبت نامی می توانند گزارشات را مشاهد کنند بدون امکان ثبت و عملیات ویرایش و حذف


## جزئیات استفاده از فیلتر در واکشی ها

## ۱. واکشی تمام محصولات به همراه فیلتر به عنوان مثال 
code=PRD-20260708-74E9CC,name=*محصول   //swagger
/api/Product/GetAll?Filter=code=PRD-20260708-74E9CC&name=*محصول   //chrome

code=PRD-20260708-74E9CC,
name=*محصول,
productId=0429e416-6f38-4df4-b2a0-c55eac904db5



## 2. واکشی تمام سندها به همراه فیلتر به عنوان مثال 
type=30,number=DOC-20260707-E25287,status=20
/api/StockDocument/GetAll?Filter=type=30&number=DOC-20260707-E25287&status=20

type=30
number=DOC-20260707-E25287
status=20

## 3. کاردکس یک کالا در بازه زمانی
/api/StockDocument/GetProductLedgerReport?ProductId=c3815044-67b6-49e6-bc46-4fa0b1e0ab7b&WarehouseId=f929168a-ae69-49d7-865a-6b9d9c757410

ProductId=c3815044-67b6-49e6-bc46-4fa0b1e0ab7b
WarehouseId=f929168a-ae69-49d7-865a-6b9d9c757410


## 4.واکشی تمام انبارها  به همراه فیلتر
code=WRH-20260707-7B3D51
name=انبار دوم
warehouseId=c2e9a22f-14f8-495c-8846-fa2a5722415f
location=اصفهان




