select 
sum(CASE WHEN atran.DebitAccount_Id= @account_id
    THEN amount
    ELSE -1*amount
END) AS amount
from AccountTransactions atran
where atran.DebitAccount_Id= @account_id or atran.CreditAccount_Id= @account_id

