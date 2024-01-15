
USE master
GO

CREATE DATABASE pizzeriaDB
GO

USE pizzeriaDB
GO

drop table pizzeriaData
go

CREATE TABLE pizzeriaData(
	OrderNo int
	,[Date] date
	,Customer varchar(100)
	,CustomerData varchar(max)
	,OrderInfo varchar(max)
	,Courier varchar(100))
GO

INSERT pizzeriaData VALUES
(1, '20170407', 'Tony Wang', 'Sportivnaya str., 15, ap.4, tel. 3-15-64', 'Pepperoni pizza - 1, beer SA - 2 (0.5)', 'Norma Mortenson')
,(2, '20170407', 'Amy Yang', 'Shevchenko av., 2, ap.17, tel. 3-22-81', 'Veggie pizza - 3, Caesar salad - 4', 'Norma Mortenson')
,(3, '20170408', 'Cheng Tsui', 'Gagarin str., 80, ap.26, tel. 3-25-70, mob. (077)444-15-17', 'beer B Premium - 10 (0.5), Meat pizza - 2, Cheese pizza - 3', 'Cassius Clay')
GO

SELECT * FROM pizzeriaData 
GO
---делаем таблицу (отношение) реляционной

DROP TABLE pizzeriaData 
GO

CREATE TABLE pizzeriaData(
	OrderNo int
	,[Date] date
	,Customer varchar(100)
	,CustomerAddress varchar(max)
	,CustomerPhone varchar(15)
	,CustomerMob varchar(15)
	,Product1 varchar(20)
	,Qty1 tinyint
	,Product2 varchar(20)
	,Qty2 tinyint
	,Product3 varchar(20)
	,Qty3 tinyint
	,Courier varchar(100))
GO

INSERT pizzeriaData VALUES
(1, '20170407', 'Tony Wang', 'Sportivnaya str., 15, ap.4', '3-15-64', NULL, 'Pepperoni pizza', 1, 'beer SA', 2, NULL, NULL, 'Norma Mortenson')
,(2, '20170407', 'Amy Yang', 'Shevchenko av., 2, ap.17', '3-22-81', NULL, 'Veggie pizza', 3, 'Caesar salad', 4, NULL, NULL, 'Norma Mortenson')
,(3, '20170408', 'Cheng Tsui', 'Gagarin str., 80, ap.26', '3-25-70', '(077)444-15-17', 'beer B Premium', 10, 'Meat pizza', 2, 'Cheese pizza', 3, 'Cassius Clay')
GO
SELECT * FROM pizzeriaData 
GO
---таблица, после этой операции не нахится в 1-ой нормальной форме
DROP TABLE pizzeriaData 
GO
CREATE TABLE pizzeriaData(
	OrderNo int
	,OrderItem int
	,[Date] date
	,Customer varchar(100)
	,CustomerAddress varchar(max)
	,CustomerPhone varchar(15)
	,CustomerMob varchar(15)
	,Product varchar(20)
	,ProductName varchar(20)
	,Qty tinyint
	,Courier varchar(100))
GO

INSERT pizzeriaData VALUES
(1, 1, '20170407', 'Tony Wang', 'Sportivnaya str., 15, ap.4', '3-15-64', NULL, 'pizza', 'Pepperoni', 1, 'Norma Mortenson')
,(1, 2, '20170407', 'Tony Wang', 'Sportivnaya str., 15, ap.4', '3-15-64', NULL, 'beer', 'SA', 2, 'Norma Mortenson')
,(2, 1, '20170407', 'Amy Yang', 'Shevchenko av., 2, ap.17', '3-22-81', NULL, 'pizza', 'Veggie', 3, 'Norma Mortenson')
,(2, 2, '20170407', 'Amy Yang', 'Shevchenko av., 2, ap.17', '3-22-81', NULL, 'salad', 'Caesar', 4, 'Norma Mortenson')
,(3, 1, '20170408', 'Cheng Tsui', 'Gagarin str., 80, ap.26', '3-25-70', '(077)444-15-17', 'beer', 'B Premium', 10, 'Cassius Clay')
,(3, 2, '20170408', 'Cheng Tsui', 'Gagarin str., 80, ap.26', '3-25-70', '(077)444-15-17', 'pizza', 'Meat', 2, 'Cassius Clay')
,(3, 3, '20170408', 'Cheng Tsui', 'Gagarin str., 80, ap.26', '3-25-70', '(077)444-15-17', 'pizza','Cheese', 3, 'Cassius Clay')
GO
SELECT * FROM pizzeriaData 
GO

DRop Table Employees
go

CREATE TABLE Employees(
	Id int
	,FullName varchar(100)
	,PositionId int)
GO

INSERT Employees VALUES
(1, 'Norma Mortenson', 1)
,(2, 'Cassius Clay', 1)
,(3, 'Samuel Clemens', 2)
,(4, 'Anna Gorenko', 3)
GO

drop table Salaries
go

CREATE TABLE Salaries(
	Id int
	,Position varchar(100)
	,Rate decimal(9,4))
GO

INSERT Salaries VALUES
(1, 'courier', 1000.00)
,(2, 'chief manager', 2000.00)
,(3, 'accountant', 1500.00)
GO



SELECT * FROM Employees
GO

SELECT * FROM Salaries
GO

