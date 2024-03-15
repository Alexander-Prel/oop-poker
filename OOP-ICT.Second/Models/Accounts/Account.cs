using OOP_ICT.Second.Exceptions;

namespace OOP_ICT.Second.Models.Accounts;

public class Account
{
    private decimal _balance;
    public decimal Balance
    {
        get => _balance;
        set
        {
            if (value < 0)
            {
                throw new NegativeBalanceException();
            }
        
            _balance = value;
        }
    }
}