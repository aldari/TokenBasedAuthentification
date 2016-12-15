select 
  id,
  dateaccount,
  amount,
  corr
from(
select 
atran.id as [id],
date as [dateaccount],
CASE WHEN DebitAccount_Id=@account_id
	THEN amount
	ELSE -1*amount
END AS amount,
CASE WHEN DebitAccount_Id=@account_id
	THEN acc.name
	ELSE acd.name
END AS corr
from AccountTransactions atran
	join accounts acc on acc.id=atran.CreditAccount_Id
	join accounts acd on acd.id=atran.DebitAccount_Id
where acc.id=@account_id or acd.id=@account_id
) t
where (@username is null or corr like '%'+@username+'%')
and (t.amount <= @amountmax)
and (t.amount >= @amountmin)
and (@datemin is null or cast([dateaccount] as datetime) >= @datemin)
and (@datemax is null or cast([dateaccount] as datetime) <= @datemax)
order by dateaccount