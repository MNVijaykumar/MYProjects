
CREATE TABLE ProductCategories (
    Id BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IsActive BIT NOT NULL,
    Category varchar(255) NOT NULL
);
go
CREATE TABLE Products (
    Id BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name varchar(255) NOT NULL,
	IsActive BIT NOT NULL,
	ImageData VARBINARY(MAX),
    ProductCategoryId BIGINT FOREIGN KEY REFERENCES ProductCategories(Id)
);
go

CREATE TABLE ProductDetails (
    Id BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Total BIGINT NOT NULL,
	Ordered BIGINT NOT NULL,
	Cost DECIMAL(18,2) NOT NULL,
    ProductId BIGINT FOREIGN KEY REFERENCES Products(Id)
);
go



INSERT INTO ProductCategories(IsActive,Category)
SELECT 1,'CupCake' UNION ALL
SELECT 1,'Cake'	   UNION ALL
SELECT 1,'Bread'   UNION ALL
SELECT 1,'Puff'	   UNION ALL
SELECT 1,'Brownies' UNION ALL
SELECT 1,'Muffin'
GO
select * from ProductCategories
INSERT INTO Products(IsActive,Name,ProductCategoryId)
SELECT 1, 'BlueBerryCupCake'	,1 UNION ALL
SELECT 1, 'StrawberryCupcakes'	,1 UNION ALL
SELECT 1, 'BrownBread'	,3		   UNION ALL
SELECT 1, 'WhiteBread'	,3		   UNION ALL
SELECT 1, 'VegPuff'	,4			   UNION ALL
SELECT 1, 'EggPuff'	,4			   UNION ALL
SELECT 1, 'VanillaCake'	,2		   UNION ALL
SELECT 1, 'ChocolateCake'	,2	   UNION ALL
SELECT 1, 'BlueBerryBrownie'	,5 UNION ALL
SELECT 1, 'ChocoChipBrownie'	,5 UNION ALL
SELECT 1, 'BlueBerryMuffin'	,6	   UNION ALL
SELECT 1, 'ChocochipMuffin'	,6
GO
select * from Products
select * from ProductDetails where ProductId=9
INSERT INTO ProductDetails(Total,Ordered,Cost,ProductId)
SELECT 10	,3	,170.00	 ,1   UNION ALL
SELECT 5	,1	,170.00	 ,2	  UNION ALL
SELECT 8	,5	,180.00	 ,3	  UNION ALL
SELECT 7	,2	,190.00	 ,4	  UNION ALL
SELECT 6	,4	,120.00	 ,5	  UNION ALL
SELECT 9	,7	,140.00	 ,6	  UNION ALL
SELECT 3	,1	,160.00	 ,7	  UNION ALL
SELECT 4	,2	,170.00	 ,8	  UNION ALL
SELECT 9	,5	,100.00	 ,9	  UNION ALL
SELECT 9	,4	,100.00  ,10  UNION ALL 
SELECT 10	,3	,45.00	 ,11  UNION ALL
SELECT 5	,1	,45.00	 ,12  

GO

