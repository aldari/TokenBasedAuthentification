select 
  id,
  dateaccount,
  amount,
  correspondent
  from 
(select 
  id,
  dateaccount,
  amount,
  ISNULL((select u.Fullname from [dbo].[AspNetUsers] u where u.Account_id =t.correspondentAccountId), 'System Account') correspondent
from(
select 
atran.id as [id],
TransDate as [Dateaccount],
CASE WHEN DebitAccount_Id=@account_id
	THEN amount
	ELSE -1*amount
END AS amount,
CASE WHEN DebitAccount_Id=@account_id
	THEN acc.id
	ELSE acd.id
END AS correspondentAccountId
from AccountTransactions atran
	join accounts acc on acc.id=atran.CreditAccount_Id
	join accounts acd on acd.id=atran.DebitAccount_Id
where acc.id=@account_id or acd.id=@account_id
) t ) t2
where (@username is null or correspondent like '%'+@username+'%')
and (amount <= @amountmax)
and (amount >= @amountmin)
and (@datemin is null or cast([dateaccount] as datetime) >= @datemin)
and (@datemax is null or cast([dateaccount] as datetime) <= @datemax)
order by dateaccount desc