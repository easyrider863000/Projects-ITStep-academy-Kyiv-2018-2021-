select p.FirstName, p.LastName, count(c.ChildrenId)
from dbo.Person p left join dbo.Children c on p.PersonId=c.PersonId
group by p.FirstName, p.LastName




