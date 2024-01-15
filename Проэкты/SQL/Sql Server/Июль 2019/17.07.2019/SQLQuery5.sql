select count(*)
from dbo.books b
where (b.Format is null or b.Format='') and b.Date is null


select b.Themes, count(*) CountThemes
from dbo.books b
group by b.Themes
order by CountThemes


select b.Themes, b.Category, count(*) CountCategory
from dbo.books b
group by b.Themes, b.Category
order by CountCategory



