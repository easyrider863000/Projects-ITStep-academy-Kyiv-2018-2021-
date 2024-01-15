--Создать процедуру которая выводит ниформацию о
--сотруднике. Если EmployeeId не задан - выводится
--информаци обо всех сотрудниках.

--if OBJECT_ID('GetEmployee','P') is not null
--	drop procedure GetEmployee
--go
--create procedure GetEmployee
--	@EmpId int =null
--	as
--	begin
--		select *
--		from dbo.Employee
--		where @EmpId is null or EmployeeId=@EmpId
--	return
--	end
--go
--exec GetEmployee 2
--exec GetEmployee


--Создать процедуру которая удаляет сотрудника из
--таблицы Employee

--if OBJECT_ID('DelEmployee','P') is not null
--	drop procedure DelEmployee
--go
--create procedure DelEmployee
--	@EmpId int =null
--	as
--	begin
--		delete from dbo.Employee
--		where EmployeeId=@EmpId
--	return
--	end
--go
--exec GetEmployee
--exec DelEmployee 2
--exec GetEmployee


--Cоздать процедуру которая добавляет сотрудника в
--таблицу Employee

--if OBJECT_ID('InsertEmployee','P') is not null
--	drop procedure InsertEmployee
--go
--create procedure InsertEmployee
--	@FirstName nvarchar(50),
--	@LastName nvarchar(50),
--	@Birthday date,
--	@Inn nchar(20)=null
--	as
--	begin
--		INSERT INTO dbo.Employee( FirstName, LastName, Birthday, Inn )
--			VALUES ( @FirstName, @LastName, @Birthday, @Inn);
--	return
--	end
--go
--exec InsertEmployee 'Vasya', 'Pupkin','20000101',222233445566
--exec GetEmployee


--Создать процедуру которая добавляет сотрудника в
--таблицы Employee и Promotion

--if OBJECT_ID('InsertEmployeePromotion','P') is not null
--	drop procedure InsertEmployeePromotion
--go
--create procedure InsertEmployeePromotion
--	@FirstName nvarchar(50),
--	@LastName nvarchar(50),
--	@Birthday date,
--	@Inn nchar(20)=null,
--	@HireDate date,
--	@Salary money=null,
--	@JobTitleId int= null
--	as
--	begin
--	if @JobTitleId is not null
--	begin
--		INSERT INTO dbo.Employee( FirstName, LastName, Birthday, Inn )
--			VALUES ( @FirstName, @LastName, @Birthday, @Inn);
--		insert into dbo.Promotion(EmployeeId, HireDate, JobTitleId, Salary)
--			values ((SELECT TOP 1 EmployeeId FROM dbo.Employee ORDER BY EmployeeId DESC), @HireDate, @JobTitleId, @Salary)
--	return
--	end
--	end
--go
--exec InsertEmployeePromotion 'Vasya', 'Pupkin','20000101',222233445566, '20100606',8000,3
--exec GetEmployee