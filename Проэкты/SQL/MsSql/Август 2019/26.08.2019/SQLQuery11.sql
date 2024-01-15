CREATE DATABASE UnionsDB
GO 

USE UnionsDB
GO

CREATE TABLE dbo.Customers
(
    Id int NOT NULL IDENTITY,
    Name varchar(100),
	Mobile varchar(20),
	EMail varchar(100)
);
GO

CREATE TABLE dbo.Suppliers
(
    Id int NOT NULL IDENTITY,
    FullName varchar(100),
	Phone varchar(15),
	Address varchar(50),
	City varchar(30)
);
GO

INSERT Customers VALUES
('Fryderyk Chopin', '(050) 196-00-32', 'chopin@warsaw.dw'),
('Peter Tchaikovsky', '(050) 196-00-34', 'ilyich@speter.re'),
('Camille Saint-Saens', '(050) 196-00-33', 'saintsaens@paris.fr'),
('George Handel', '(050) 196-00-31', 'handel@halle.sri');
GO

INSERT Suppliers VALUES
('Camille Saint-Saens', '(050) 196-00-33', 'rue du Jardinet', 'Paris'),
('George Handel', '050-196-00-31', 'Westminster Abbey', 'London'),
('Sergei Rachmaninoff', '(050) 196-00-35', '505 West End Avenue', 'New York'),
('Antonio Vivaldi', '(050) 196-00-36', 'Ospedale della Pieta', 'Venice');
GO



CREATE TABLE dbo.EmployeeNames
(
    Id int NOT NULL IDENTITY,
    Name varchar(100),
);
GO

INSERT EmployeeNames VALUES
('Fryderyk Chopin'),
('George Handel'),
('Antonio Vivaldi');
GO
