using OOP_ICT.Second.Exceptions;
using OOP_ICT.Second.Models.Accounts;

namespace OOP_ICT.Second.Models;

public class Casino : AccountsFactory<CasinoAccount>
{
    public new void CreateAccount(Player player)
    {
        var account = new CasinoAccount
        {
            Balance = InitialBalance,
            CurrentBet = 0
        };
        Accounts.Add(player, account);
    }
    
    public decimal GetAccountBet(Player player)
    {
        return Accounts[player].CurrentBet;
    }

    public void MakeBet(Player player, decimal amount)
    {
        var balance = GetAccountBalance(player);
        if (balance - amount < 0)
        {
            throw new NotEnoughMoneyException("Player dont have enough money");
        }
        Debit(player, amount);
        Accounts[player].CurrentBet = amount;
    }

    public void ClearBet(Player player)
    {
        Accounts[player].CurrentBet = 0m;
    }
}