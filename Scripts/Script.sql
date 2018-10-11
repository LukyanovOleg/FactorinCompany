Select FT.ClientName, MONTH ( FT.Date ) [Month], sum(FT.Amount) [SumAmount]
from FactorinTest FT
where Year(FT.Date) = 2017
group by FT.ClientName, MONTH ( FT.Date )
order by FT.ClientName, MONTH ( FT.Date )