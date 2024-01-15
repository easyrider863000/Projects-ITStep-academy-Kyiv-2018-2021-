--select *
--from TableA
--select *
--from TableB


select a.id idA, a.name nameA, b.id idB, b.name nameB
from TableB b full join TableA a on a.id=b.id
order by 1

select a.id idA, a.name nameA, b.id idB, b.name nameB
from TableB b left join TableA a on a.id=b.id
union
select a.id idA, a.name nameA, b.id idB, b.name nameB
from TableB b right join TableA a on a.id=b.id

order by 1
