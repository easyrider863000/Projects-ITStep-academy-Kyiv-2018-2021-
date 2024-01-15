-- процедура добавления данных

--go
--if object_id('AddDataConverter','P') is not null
--	drop procedure AddDataConverter
--go
--create procedure AddDataConverter
--@Type nvarchar(10),
--@HRN money =null
--as
--begin
--	if @HRN is not null and len(@Type)>=3
--		begin
			
--			INSERT INTO dbo.Converter( CurrentDate, Type, Unit, Hryvnia)
--			VALUES ( GETDATE(),@Type, 1,@HRN);
--		end
--end
--go
--exec AddDataConverter 'euro', 29.8
--select *
--from dbo.Converter


-- процедура удаления данных

--if object_id('DelDataConverter','P') is not null
--	drop procedure DelDataConverter
--go
--create procedure DelDataConverter
--@ConvertId int
--as
--begin			
--	delete from dbo.Converter
--	where @ConvertId=ConverterId
--end
--go
--exec DelDataConverter 1
--select *
--from dbo.Converter


-- процедура обновления даных

--if object_id('UpdateDataConverter','P') is not null
--	drop procedure UpdateDataConverter
--go
--create procedure UpdateDataConverter
--@ConverterId int=null,
--@HRN money=null
--as
--begin
--if @HRN is not null
--	begin
--		update dbo.Converter
--		set Hryvnia = @HRN
--		where ConverterId=@ConverterId
--	end
--end
--go
--exec UpdateDataConverter 1, 29.8
--select *
--from dbo.Converter


-- процедура которая возвращает значения колонки Hryvnia в зависимости от даты

--if object_id('GetHRNConverter','P') is not null
--	drop procedure GetHRNConverter
--go
--create procedure GetHRNConverter
--@CurrentDate date
--as
--begin
--	select Hryvnia
--	from dbo.Converter
--	where CurrentDate=(select max(c.CurrentDate)
--						from Converter c
--						where c.CurrentDate<=@CurrentDate
--						)
--end
--go
--exec GetHRNConverter '20150307'
--select *
--from dbo.Converter