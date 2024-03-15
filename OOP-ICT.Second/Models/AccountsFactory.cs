using OOP_ICT.Second.Exceptions;
using OOP_ICT.Second.Models.Accounts;

namespace OOP_ICT.Second.Models;

public abstract class AccountsFactory<T>
    where T : Account, new()
{
    public decimal InitialBalance = 100m;
    protected readonly Dictionary<Player, T> Accounts = new();

    public void CreateAccount(Player player)
    {
        var account = new T
        {
            Balance = InitialBalance
        };
        Accounts.Add(player, account);
    }

    public decimal GetAccountBalance(Player player)
    {
        return Accounts.TryGetValue(player, out var account) ? account.Balance : throw new NoSuchAccountException(
            "Player hasn't any accounts");
    }

    public void SetAccountBalance(Player player, decimal amount)
    {
        try
        {
            Accounts[player].Balance = amount;
        }
        catch (KeyNotFoundException)
        {
            throw new NoSuchAccountException("Player hasn't any accounts");
        }
    }

    public void Debit(Player player, decimal amount)
    {
        if (GetAccountBalance(player) < amount)
        {
            throw new NotEnoughMoneyException("Player hasn't enough money on his account");
        }

        Accounts[player].Balance -= amount;
    }

    public void Credit(Player player, decimal amount)
    {
        Accounts[player].Balance += amount;
    }
}