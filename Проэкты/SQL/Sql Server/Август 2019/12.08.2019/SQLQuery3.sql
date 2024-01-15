--select *
--from TableA


--select a.id idA, a.name nameA, b.id idB, b.name nameB
--from TableA a, TableB b

--select a.id idA, a.name nameA, b.id idB, b.name nameB
--from TableA a cross join TableB b

select *
from TableA
select *
from TableB

select a.id idA, a.name nameA, b.id idB, b.name nameB
from TableA a join TableB b on a.name=b.name and a.id=b.id









