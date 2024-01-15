USE master
GO


CREATE DATABASE PartsDB
GO

USE PartsDB
GO
CREATE TABLE Manufacturer(
	Id int identity primary key,
	[Name] nvarchar(100) not null,
	Country varchar(100),
	PhotoPath nvarchar(2048) default 'https://img.icons8.com/ios-filled/2x/unsplash.png'
)
GO


CREATE TABLE Category(
	Id int identity primary key,
	[Name] nvarchar(100) not null,
	PhotoPath nvarchar(2048) default 'https://img.icons8.com/ios-filled/2x/unsplash.png'
)
GO


CREATE TABLE Supplier(
	Id int identity primary key,
	[Name] nvarchar(200) not null,
	[Description] nvarchar(4000)
)
GO


CREATE TABLE StatusDelivery(
	Id int identity primary key,
	[Name] nvarchar(200) not null,
	[Description] nvarchar(4000)
)
GO


CREATE TABLE [Address](
	Id int identity primary key,
	[Country] nvarchar(200) not null,
	[City] nvarchar(200) not null,
	[Street] nvarchar(200) not null,
	[House] nvarchar(200) not null,
	[Flat] nvarchar(200),
	[Description] nvarchar(4000)
)
GO


CREATE TABLE AddressPhoneNumber(
	Id int identity primary key,
	IdAddress int not null FOREIGN KEY REFERENCES [Address](Id),
	PhoneNumber varchar(16) not null
)
GO


CREATE TABLE AddressMail(
	Id int identity primary key,
	IdAddress int not null FOREIGN KEY REFERENCES [Address](Id),
	Mail varchar(320) not null
)
GO



CREATE TABLE [Role](
	Id int identity primary key,
	[Name] nvarchar(100) not null
)
GO

CREATE TABLE Client(
	Id int identity primary key,
	[Name] nvarchar(100) not null,
	[SurName] nvarchar(100) not null,
	[Description] nvarchar(4000),
	PriceDelivery float default 0.1,
  [Token] nvarchar(2048) null,
	[Login] varchar(100) not null,
	[Password] varchar(100) not null,
	[IdRole] int not null FOREIGN KEY REFERENCES [Role](Id)
)
GO


CREATE TABLE SupplierAddress(
	Id int identity primary key,
	[IdSupplier] int not null FOREIGN KEY REFERENCES [Supplier](Id),
	[IdAddress] int not null FOREIGN KEY REFERENCES [Address](Id),
)
GO


CREATE TABLE ClientAddress(
	Id int identity primary key,
	[IdClient] int not null FOREIGN KEY REFERENCES [Client](Id),
	[IdAddress] int not null FOREIGN KEY REFERENCES [Address](Id),
)
GO


CREATE TABLE Good(
	Id int identity primary key,
	[Name] nvarchar(1000) not null,
	Number nvarchar(200),
	[Description] nvarchar(4000),
	[IdManufacturer] int not null FOREIGN KEY REFERENCES [Manufacturer](Id),
	[IdCategory] int not null FOREIGN KEY REFERENCES [Category](Id),
	[IdSupplier] int not null FOREIGN KEY REFERENCES [Supplier](Id),
	Price money not null,
	IsBeating bit,
	IsLiquid bit,
	PhotoPath nvarchar(2048) default 'https://img.icons8.com/ios-filled/2x/unsplash.png'
)
GO

create table [OrderDetails](
	Id int identity primary key,
	[IdStatus] int not null FOREIGN KEY REFERENCES [StatusDelivery](Id),
	OrderDate date
)
go


CREATE TABLE [Order](
	Id int identity primary key,
	[IdClient] int not null FOREIGN KEY REFERENCES [Client](Id),
	[IdGood] int not null FOREIGN KEY REFERENCES [Good](Id),
	[Count] numeric(5,0) default 1,
	[IdOrderDetails] int not null FOREIGN KEY REFERENCES [OrderDetails](Id),
)
GO




















INSERT StatusDelivery VALUES
('У поставщика', 'Товар у поставщика'),
('В пути', 'Товар в дороге'),
('На складе', 'Товар приехал на склад')
GO


INSERT into Manufacturer ([Name], Country) 
VALUES
('Febi Bilstein', 'Germany'),
('Meyle', 'Germany'),
('ATE', 'Germany'),
('BERU', 'Germany'),
('BOSCH', 'Germany'),
('Zimmerman', 'Germany'),
('ZF', 'Germany'),
('Behr Hella Service', 'Germany'),
('SASCH', 'Germany'),
('PIERBURG', 'Germany'),
('FAG', 'Germany'),
('KNECHT', 'Germany'),
('LEMFORDER', 'Germany'),
('GLYCO', 'Germany'),
('RUVILLE', 'Germany'),
('MOOG', 'Germany'),
('Contitech', 'Germany'),
('Aks Dasis', 'Germany'),
('Corteco', 'Germany'),
('Elring', 'Germany'),
('Prasco', 'Germany'),
('LuK', 'Germany'),
('Sachs', 'Germany'),
('Vaico', 'Germany'),
('Johns', 'Germany'),
('Swag', 'Germany'),
('KM Germany', 'Germany'),
('Topran', 'Germany'),
('Truckrec Automotive', 'Germany'),
('Master-Sport', 'Germany'),
('SNR', 'France'),
('Sasic', 'France'),
('Valeo', 'France'),
('ELF', 'France'),
('Total', 'France'),
('Monroe', 'USA'),
('TRW', 'USA'),
('GATES', 'USA'),
('Dayco', 'USA'),
('DELPHI', 'USA'),
('SHELL', 'Netherlands'),
('AVA Quality Cooling', 'Netherlands'),
('Kawe', 'Netherlands'),
('BREMBO', 'Italy'),
('Hoffer', 'Italy'),
('Sidat', 'Italy'),
('Meat&Doria', 'Italy'),
('Fispa', 'Italy'),
('Raicam', 'Italy'),
('Ajusa', 'Spain'),
('Autofren', 'Spain'),
('3RG', 'Spain'),
('Sercore', 'Spain'),
('Triclo', 'Spain'),
('FERODO', 'England'),
('Comma', 'England'),
('Castrol', 'England'),
('Lucas Electrical', 'England'),
('Borg&Beck', 'England'),
('Quinton Hazell', 'England'),
('Comline', 'England'),
('National', 'England'),
('Lucas Engine Drive', 'England'),
('JP Group', 'Dania'),
('Nipparts', 'Dania'),
('Elstock', 'Dania'),
('DRI', 'Dania'),
('NK', 'Dania'),
('sbs', 'Dania'),
('Klokkerholm', 'Dania'),
('Triscan', 'Dania'),
('Kayaba', 'Japan'),
('Denso', 'Japan'),
('Exedy', 'Japan'),
('CTR', 'Korea'),
('ABE', 'Poland'),
('MaxGear', 'Poland'),
('Polcar', 'Poland'),
('Loro', 'Poland'),
('Nexus', 'Poland'),
('SKF', 'Sweden'),
('Van Wezel', 'Belgium'),
('Patron', 'China'),
('MAPA', 'Turkey')
GO


INSERT into Category ([Name]) 
VALUES
('Двигатель'),
('Детали кузова автомобиля'),
('Детали системы охлаждения автомобиля'),
('Жидкости омывателя'),
('Замки противоугонные'),
('Инструменты'),
('Кондиционирование'),
('Отопление, вентиляция'),
('Очистка стекол'),
('Присадки в топливо'),
('Рулевые механизмы, рейки'),
('Сувениры'),
('Топливная система'),
('Тормозная система'),
('Трансмиссия'),
('Электроника'),
('Автохимия прочее'),
('Масла')
GO


INSERT into Supplier([Name]) 
VALUES
('AVDtrade'),
('SMAPauto'),
('VG SERVICE LTC'),
('AME / Auto Market Experts'),
('DHA Deutsche Handelsallianz GmbH'),
('TRIBO'),
('VBR Electric'),
('POLY BUSH'),
('ATG Ukraine'),
('EXIST.UA')
GO


INSERT into [Address]([Country], [City], [Street], [House], [Flat])
VALUES
('Ukrane','Kyiv','Василия Стуса улица','1','15'),
('Ukrane','Kyiv','Коперника улица','4','123'),
('Ukrane','Kyiv','Красногвардейский переулок','1','432'),
('Ukrane','Kyiv','Левандовская улица','3','1'),
('Ukrane','Kyiv','Лисковская улица','12','43'),
('Ukrane','Kyiv','Малая Житомирская улица','64','12'),
('Ukrane','Kyiv','Маршала Жукова улица','23','65'),
('Ukrane','Kyiv','Нежинская улица','32','32'),
('Ukrane','Kyiv','Николая Гастелло улица','4','90'),
('Ukrane','Kyiv','Обуховская улица','21','243'),
('Ukrane','Kyiv','Ольгинская улица','12','67'),
('Ukrane','Kyiv','Петра Кайсарова улица','9','145'),
('Ukrane','Kyiv','Пешеходный переулок','5','109'),
('Ukrane','Kyiv','Радужная улица','17','23'),
('Ukrane','Kyiv','Рощинский переулок','4','45'),
('Ukrane','Kyiv','Северная улица','16','89'),
('Ukrane','Kyiv','Сентябрьская улица','19','24'),
('Ukrane','Kyiv','Тараса Шевченко бульвар','9','90'),
('Ukrane','Kyiv','Ташкентская улица','7','121'),
('Ukrane','Kyiv','Ужгородская улица','23','78')
GO


INSERT into AddressPhoneNumber(IdAddress, PhoneNumber)
VALUES				  
(1,'0505201545'),
(2,'0675641289'),
(3,'0637892345'),
(4,'0934563298'),
(5,'0504563217'),
(6,'0975649832'),
(7,'0637986512'),
(8,'0994569832'),
(9,'0971237865'),
(10,'0507895612'),
(11,'0678524196'),
(12,'0994563298'),
(13,'0502583696'),
(14,'0991239845'),
(15,'0665643245'),
(16,'0977896523'),
(17,'0672851495'),
(18,'0932378965'),
(19,'0985215364'),
(20,'0994564531'),
(1,'0935463287'),
(2,'0631236578'),
(11,'0554569820'),
(15,'0995621324'),
(2,'0954560828'),
(6,'0632584796'),
(17,'0502003020'),
(18,'0984561237'),
(9,'0677893210'),
(12,'0993245598')
GO


INSERT into AddressMail(IdAddress, Mail)
VALUES
(1,'offf@gmail.com'),
(2,'vasya@gmail.com'),
(3,'petyap@gmail.com'),
(4,'wqetry@gmail.com'),
(5,'asdg228@gmail.com'),
(6,'offf234@gmail.com'),
(7,'ikmfrhj3@gmail.com'),
(8,'vasil26@gmail.com'),
(9,'georgii233@gmail.com'),
(10,'oleg228@gmail.com'),
(11,'valentinaKA61@gmail.com'),
(12,'tyghbnhello@mail.com'),
(13,'vasya@gmail.com'),
(14,'karatist@gmail.com'),
(15,'durakauto@gmail.com'),
(16,'badclient@gmail.com'),
(17,'Mavpa232apvaM@gmail.com'),
(18,'andrei_bei@gmail.com'),
(19,'Do_official@gmail.com'),
(20,'mamamia@gmail.com'),
(1,'superman@gmail.com'),
(2,'halk328o@gmail.com'),
(10,'mynameis@gmail.com'),
(12,'helpmeplease@gmail.com'),
(19,'pizzaMe53@gmail.com')
GO


INSERT into [Role]([Name])
VALUES
('admin'),
('director'),
('manager'),
('user')
GO


INSERT into Client([Name], Surname,[Login],[Password],IdRole)
VALUES
('Иван','Петров','admin','21232f297a57a5a743894a0e4a801fc3',1),
('Максим','Гунько','manager','1d0258c2440a8d19e716292b231e3190',3),
('Андрей','Борисенко','director','d8578edf8458ce06fbc5bb76a58c5ca4',2),
('Петро','Бреус','hello123','827ccb0eea8a706c4c34a16891f84e7b',4),
('Анатолий','Борошенко','vasya21','fc5e038d38a57032085441e7fe7010b0',4),
('Вероника','Серденко','petya09','f30aa7a662c728b7407c54ae6bfd27d1',4),
('Ольга','Шмалякова','valentina','9d2d78d5a3b94b940620e63f528498fa',4),
('Клавдия','Шиференко','foxfox','70a5d255a4109da344424e6bc9bb40c0',4),
('Борис','Вилько','wolfparts','ca5757b6f6b2bb13eee4fb73cc44a5ee',4),
('Арнольд','Шварценко','forest','dbe6af65c404e01eb6ba2d4e1a3734d4',4)
GO


INSERT into SupplierAddress(IdSupplier, IdAddress)
VALUES
(1,1),
(2,2),
(3,3),
(4,4),
(5,5),
(6,6),
(7,7),
(8,8),
(9,9),
(10,10)
GO


INSERT into ClientAddress(IdClient, IdAddress)
VALUES
(1,11),
(2,12),
(3,13),
(4,14),
(5,15),
(6,16),
(7,17),
(8,18),
(9,19),
(10,20)
GO


INSERT into Good([Name], Number, IdManufacturer, IdCategory, IdSupplier, Price, IsBeating, IsLiquid)
VALUES
('Прокладки двигателя','170518', 20, 1, 1, 0.13, 1, 0),
('Гидрокомпенсатор', '100105', 28, 1, 2, 0.26, 0, 0),
('Крепление крыла', '31849', 1, 2, 3, 3.15, 1, 0),
('Арка заднего крыла', 'H9521595', 70, 2, 4, 4.20, 0, 0),
('Удерживающая пружина', '109633', 28, 3, 5, 0.3, 0, 0),
('Жидкость в бачок омивателя, -65 *С, 5L', 'XSW5L', 56, 4, 6, 4.25, 0, 1),
('Элемент замка кабины', 'V109745', 24, 5, 7, 0.18, 0, 0),
('Комплект монтажних приспособлений', '400042010', 22, 6, 8, 165.3, 1, 0),
('Комплектующие для смазки', 'MANISTAACCES10L', 56, 6, 9, 13.3, 1, 0),
('Комплект уплотнительных колец, кондиционер', '06951060', 40, 7, 10, 0.5, 1, 0),
('Монтажные элементы кондиционера', '114053', 28, 7, 1, 0.5, 1, 0),
('Монтажный элемент радиатора', 'V207101', 24, 8, 2, 1, 0, 0),
('Элемент стеклоочистителя', '3392390298', 5, 9, 3, 0.32, 1, 0),
('Счетка стеклоочистителя', 'UB425', 65, 9, 4, 0.77, 1, 0),
('Присадка в бензин', 'Cas 25-250', 57, 10, 5, 11, 0, 1),
('Осевой шарнир, рулевая тяга', 'HYAX3939', 16, 11, 6, 1.08, 0, 0),
('Наконечник поперечной рулевой тяги', '4006117', 32, 11, 7, 1.25, 0, 0),
('Пыльник, рулевое управление', '62919919', 26, 11, 8, 1.79, 0, 0),
('Датчик уровня топлива', '347520', 33, 13, 9, 46.83, 1, 0),
('Фильтр топлива', 'V100338', 24, 13, 10, 1.83, 0, 0),
('Фильтр топлива', 'V301832', 14, 13, 1, 11.62, 0, 0),
('Направляющая гильза, корпус скобы тормоза', '11817100221', 3, 14, 2, 0.23, 0, 0),
('Болт, корпус скобы тормоза', '110710', 28, 14, 3, 0.25, 0, 0),
('Направляющая гильза, система сцепления', '24221', 52, 15, 4, 5.41, 0, 0),
('Трос управления сцеплением', '923741', 68, 15, 5, 20.98, 0, 0),
('Автомобильная лампа', '1987302516', 5, 16, 6, 0.08, 1, 0),
('Прокладки двигателя', '110507', 20, 17, 7, 0.19, 1, 1),
('Уплотнитель двигателя', '33836', 1, 17, 8, 0.24, 1, 1),
('Гидравлический насос, рулевое управление', '320106', 77, 18, 9, 1.17, 0, 1),
('Комплект прокладок, гидравлический насос', '107356', 28, 18, 10, 1.86, 0, 1)
GO

insert into [OrderDetails](IdStatus, Orderdate)
values
(1,'2020-01-20'),
(2,'2020-02-20'),
(3,'2020-01-24')
go


INSERT into [Order](IdClient, IdOrderDetails, IdGood, [Count])
VALUES
(1,1,1,5),
(1,1,2,10),
(1,1,3,3),
(1,1,4,6),
(2,2,5,9),
(2,2,6,20),
(2,2,7,30),
(2,2,8,50),
(2,2,9,15),
(3,2,10,13),
(3,2,11,2),
(3,2,12,45),
(3,2,13,9),
(3,2,14,32),
(3,3,15,3),
(3,3,16,4),
(3,3,17,4),
(3,3,18,5),
(6,3,19,5),
(6,3,20,8),
(6,3,21,9),
(6,3,22,18),
(9,1,23,23),
(9,1,24,13),
(9,1,25,17),
(9,1,26,20),
(8,2,27,8),
(8,2,28,9),
(8,2,29,16),
(8,2,30,14)
GO