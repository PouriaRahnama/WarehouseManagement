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


## واکشی تمام انبارها  به همراه فیلتر .4 
code=WRH-20260707-7B3D51
name=انبار دوم
warehouseId=c2e9a22f-14f8-495c-8846-fa2a5722415f
location=اصفهان




