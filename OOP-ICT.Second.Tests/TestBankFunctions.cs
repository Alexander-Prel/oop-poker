using OOP_ICT.Second.Exceptions;
using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Second.Tests;

public class TestBankFunctions
{
    [Fact]
    public void TestCreateAccount()
    {
        var bank = new Bank();
        
        var player = new Player();
        bank.CreateAccount(player);

        try
        {
            bank.GetAccountBalance(player);
        }
        catch (NoSuchAccountException)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public void TestDebit()
    {
        var bank = new Bank();
        
        var player = new Player();
        bank.CreateAccount(player);

        const decimal testAmount = 100;
        bank.Debit(player, testAmount);
        
        Assert.Equal(bank.InitialBalance - testAmount, bank.GetAccountBalance(player));
    }

    [Fact]
    public void TestCredit()
    {
        var bank = new Bank();
        
        var player = new Player();
        bank.CreateAccount(player);

        const decimal testAmount = 100;
        bank.Credit(player, testAmount);
        
        Assert.Equal(bank.InitialBalance + testAmount, bank.GetAccountBalance(player));
    }
}