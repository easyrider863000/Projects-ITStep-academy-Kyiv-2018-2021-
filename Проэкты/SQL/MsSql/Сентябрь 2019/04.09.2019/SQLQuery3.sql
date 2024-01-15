begin tran
	begin try
		select *
		from Employee
		commit
	end try

	begin catch
		rollback
		print 'error'
	end catch