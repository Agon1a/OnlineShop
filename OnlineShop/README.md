# Prepare to work
Для начала необходимо создать на сервере MSSQL базу данных onlineshop:
```sql
CREATE DATABASE onlineshop
```
Далее, в консоли диспетчера пакетов (Вид -> Другие окна -> Консоль диспетчера пакетов) выполнить команду:
```powershell
Update-Database
```
Затем в базе данных добавить триггер
```sql
CREATE TRIGGER trg_CreateShoppingCartOnUserInsert
ON Users
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ShoppingCart (UserId)
    SELECT i.UserId
    FROM inserted i;
END;
```
# How to configure SQLConnection
Т.к. названия серверов на рабочих ПК у всех разные, есть 2 варианта подключения:
1. "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=onlineshop;Trusted_Connection=True;TrustServerCertificate=true;"
2. "SecondConnection": "Server=localhost;Database=onlineshop;Trusted_Connection=True;TrustServerCertificate=true;"

В зависимости от названия сервера, необходимо в Program.cs указать необходимое подключение
Примеры:

1.
```sql
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
```
2.
```sql
string connection = builder.Configuration.GetConnectionString("SecondConnection");
```