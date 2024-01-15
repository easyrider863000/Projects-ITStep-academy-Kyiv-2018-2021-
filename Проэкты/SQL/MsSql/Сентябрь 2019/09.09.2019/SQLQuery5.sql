;with Prefix(Prefix)
as
(
	select 100 
	union all
	select Prefix + 1
	from Prefix
	where Prefix < 600
)

select *
from Prefix