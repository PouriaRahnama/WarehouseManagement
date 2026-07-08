# سامانه مدیریت انبار (Warehouse Management System)
این پروژه برای مدیریت موجودی انبار است که با استفاده از تکنولوژی های زیر پیاده‌سازی شده است.
**ASP.NET Core 6**، **Entity Framework Core** و **SQL Server**

##  ویژگی‌های فنی
- **معماری =>  Clean Architecture
برای جداسازی مسئولیت‌ها.

- **یکپارچگی استفاده از => UnitOfWork(Transaction) 
برای عملیات چندمرحله‌ای انبار.
و انجام عملیات به صورت کامل یا هیچ و مدیریت صحت موجودی انبار

- **همزمانی پیاده‌سازی  => Optimistic Concurrency
با استفاده از =>  `RowVersion`

### پیش‌نیازها
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download)
- SQL Server 2019

### ۱. تنظیمات کانکشن استرینگ
فایل =>  `appsettings.json`
را در پروژه  باز کرده و مقدار => `ConnectionStrings`
را مطابق دیتابیس خود تنظیم کنید

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



