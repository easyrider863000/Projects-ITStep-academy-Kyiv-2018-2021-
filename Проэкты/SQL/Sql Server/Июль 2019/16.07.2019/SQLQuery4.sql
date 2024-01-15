select *
from HR.Employees e
where e.firstname not like '[sd]%'
order by firstname, lastname