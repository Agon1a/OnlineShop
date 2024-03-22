CREATE TRIGGER trg_CreateShoppingCartOnUserInsert
ON AspNetUsers
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ShoppingCart (UserId)
    SELECT i.Id
    FROM inserted i;
END;



INSERT INTO UserAddresses (UserId, AdressName, Street, House, Flat, Entrance, Floor)
VALUES 
(1, 'Home', 'Main Street', '123', 'Apt 1', 'Entrance A', '1st Floor'),
(1, 'Work', 'Business Avenue', '456', 'Suite 10', NULL, '2nd Floor'),
(1, 'Vacation Home', 'Beach Road', '789', 'Beach House', NULL, 'Ground Floor'),
(1, 'Parents House', 'Family Lane', '321', NULL, NULL, 'Basement'),
(2, 'Home', 'Oak Street', '555', 'Unit 5', NULL, '3rd Floor'),
(2, 'Office', 'Downtown Avenue', '777', 'Floor 12', 'Tower Entrance', '12th Floor'),
(2, 'Cabin Retreat', 'Pine Road', '999', NULL, NULL, 'Cabin Level'),
(2, 'Holiday Villa', 'Sunset Boulevard', '111', 'Villa 3', NULL, 'Poolside'),
(3, 'Home', 'Maple Lane', '222', 'Apartment 7', NULL, '2nd Floor'),
(3, 'Company Office', 'Tech Park Street', '444', 'Office 20', NULL, '4th Floor'),
(3, 'Mountain Chalet', 'Alpine Road', '666', NULL, NULL, 'Ski Lodge Level'),
(3, 'Beach House', 'Seaside Drive', '888', NULL, NULL, 'Beachfront'),
(4, 'Home', 'Palm Avenue', '7777', 'House 1A', NULL, 'Ground Floor'),
(4, 'Studio Apartment', 'City Center Road', '9999', 'Unit 15B', NULL, '15th Floor'),
(4, 'Lake Cottage', 'Waterfront Drive', '3333', NULL, NULL, 'Lakeside Level'),
(4, 'Country Farmhouse', 'Rural Route 5', '5555', NULL, NULL, 'Farm Level');

INSERT INTO Categories (CategoryName)
VALUES
('Овощи/Фрукты'),       -- 1
('Мясные изделия'),     -- 2
('Готовая еда'),        -- 3
('Морепродукты'),       -- 4
('Сладости'),           -- 5
('Молочные продукты'),  -- 6
('Выпечка'),            -- 7
('Напитки');            -- 8

INSERT INTO Products(ProductName, Description, Cost, CategoryId)
VALUES
('Банан 1 шт.', 'Банан бразильский', 76, 1),
('Говядина вырезка 1 кг.', 'Говядина Земная', 590, 2),
('Яки нику', 'Очень вкусно', 290, 3),
('Креветки северные 1 кг.', 'Креветки северные, мертвые', 600, 4),
('Торт Наполенон 1 кг.', 'Торт вкусный, сам ел', 500, 5),
('Молоко 1 л.', 'Молоко деревенское', 76, 6),
('Пирожок с капустой 1 шт.', 'Пирожок бабушкин', 76, 7),
('Сок яблочный 1 л.', 'Кислый', 90, 8);
