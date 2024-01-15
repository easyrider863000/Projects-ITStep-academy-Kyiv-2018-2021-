--1 Выбрать книги стомиостью от 20 до 25 грн.
--select *
--from dbo.books b
--where b.Price>=20 and b.Price<=25


--2 Выбрать книги у которых не задана дата выпуска
--select *
--from dbo.books b
--where b.Date is null


--3 Выбрать книги у которых неизвестно кол-во страниц
--select *
--from dbo.books b
--where b.Pages is null


--4 Выбрать книги у которых неизвестен формат!!!
--select *
--from dbo.books b
--where b.Format is null or b.Format=''


--5 Выбрать книги издательсва Вильямс, у которых не указана дата выпуска
--select *
--from dbo.books b
--where b.Izd='Вильямс' and b.Date is null


--6 Выбрать книги стомиостью менее 10 и более 20 грн и отсортировать их по цене и дате выпуска
--select *
--from dbo.books b
--where b.Price<10 or b.Price>20
--order by b.Price, b.Date


--7 Выбрать книги дата выпуска которых лежит в заданном диапазоне
--select *
--from dbo.books b
--where b.Date>='2000.01.01' and b.Date<='2001.01.01'


--8 Выбрать книги по теме  CorelDRAW 9
--select *
--from dbo.books b
--where b.Name like '%CorelDRAW%9%' 


--9 Выбрать книги по теме  CorelDRAW 9 издательства Питер
--select *
--from dbo.books b
--where b.Name like '%CorelDRAW%9%' and b.Izd='Питер'


--10 Выбрать книги у которых формат и дата выпуска не заданы
--select *
--from dbo.books b
--where b.Format is null and b.Date is null


--11 Выбрать книги у которых в названии РОВНО две буквы 'о'
--select *
--from dbo.books b
--where (b.Name like '%о%о%' and b.Name not like '%о%о%о%')