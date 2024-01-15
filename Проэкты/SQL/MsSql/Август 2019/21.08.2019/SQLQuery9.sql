select *
from TSQL2012.dbo.ProductionProducts


update TSQL2012.dbo.ProductionProducts
set
discontinued=0
where categoryid=1