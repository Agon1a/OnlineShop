CREATE TABLE [Categories]
(
 [CategoryId]   int IDENTITY (1, 1) NOT NULL ,
 [CategoryName] varchar(50) NOT NULL 

);
GO

CREATE TABLE [Products]
(
 [ProductId]   int IDENTITY (1, 1) NOT NULL ,
 [Cost]        numeric NOT NULL ,
 [ProductName] varchar(120) NOT NULL ,
 [Description] text NOT NULL ,
 [CategoryId]  int NULL 

);
GO


CREATE NONCLUSTERED INDEX [FK_2] ON [Products] 
 (
  [CategoryId] ASC
 )

GO

CREATE TABLE [Users]
(
 [UserId]       int IDENTITY (1, 1) NOT NULL ,
 [Email]        varchar(max) NOT NULL ,
 [UserName]     varchar(max) NOT NULL ,
 [UserPassword] varchar(max) NOT NULL ,
 [PhoneNumber]  varchar(12) NOT NULL ,
 [Bonuses]      int NULL 

);
GO

CREATE TABLE [UserAddresses]
(
 [AdressId]   int IDENTITY (1, 1) NOT NULL ,
 [UserId]     int NOT NULL ,
 [AdressName] varchar(50) NOT NULL ,
 [Street]     varchar(50) NOT NULL ,
 [House]      varchar(50) NOT NULL ,
 [Flat]       varchar(50) NULL ,
 [Entrance]   varchar(50) NULL ,
 [Floor]      varchar(50) NOT NULL 

);
GO


CREATE NONCLUSTERED INDEX [FK_1] ON [UserAddresses] 
 (
  [UserId] ASC
 )

GO

CREATE TABLE [Orders]
(
 [OrderId]      int IDENTITY (1, 1) NOT NULL ,
 [UserId]       int NOT NULL ,
 [OrderDate]    date NOT NULL ,
 [TotalPrice]   numeric NOT NULL ,
 [ProductsJson] nvarchar(max) NOT NULL CONSTRAINT [DF_Orders_ProductsJson] DEFAULT '{}' 

);
GO


CREATE NONCLUSTERED INDEX [FK_4] ON [Orders] 
 (
  [UserId] ASC
 )

GO

CREATE TABLE [ShoppingCart]
(
 [CartId]       int IDENTITY (1, 1) NOT NULL ,
 [UserId]       int NOT NULL ,
 [ProductsJson] nvarchar(max) NOT NULL CONSTRAINT [DF_ShoppingCart_ProductsJson] DEFAULT '{}' 

);
GO


CREATE NONCLUSTERED INDEX [FK_3] ON [ShoppingCart] 
 (
  [UserId] ASC
 )

GO

--Keys
ALTER TABLE Categories
ADD CONSTRAINT PK_Categories PRIMARY KEY (CategoryId);

ALTER TABLE Products
ADD CONSTRAINT PK_Products PRIMARY KEY (ProductId);

ALTER TABLE Products
ADD CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId);

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (UserId);

ALTER TABLE Orders
ADD CONSTRAINT PK_Orders PRIMARY KEY (OrderId)

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Users FOREIGN KEY (UserId) REFERENCES Users(UserId);

ALTER TABLE UserAddresses
ADD CONSTRAINT PK_UserAdresses PRIMARY KEY (AdressId, UserId)

ALTER TABLE UserAddresses
ADD CONSTRAINT FK_UserAddresses_Users FOREIGN KEY (UserId) REFERENCES Users(UserId);

ALTER TABLE ShoppingCart
ADD CONSTRAINT PK_ShoppingCart PRIMARY KEY (CartId, UserId)

ALTER TABLE ShoppingCart
ADD CONSTRAINT FK_ShoppingCart_Users FOREIGN KEY (UserId) REFERENCES Users(UserId);