BEGIN TRAN
	SAVE TRANSACTION  point1 
		delete from EmployeeMilitary
		where EmployeeId=4

		delete from Promotion
		where EmployeeId=4;
		delete from Employee
		where EmployeeId=4;
		SAVE TRANSACTION  point2 
select * 
from Employee
ROLLBACK TRANSACTION point1
select * 
from Employee
ROLLBACK TRANSACTION
