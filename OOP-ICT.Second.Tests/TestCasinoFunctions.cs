using OOP_ICT.Second.Exceptions;
using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Second.Tests;

public class TestCasinoFunctions
{
    
    [Fact]
    public void TestCreateAccount()
    {
        var casino = new Casino();
        
        var player = new Player();
        casino.CreateAccount(player);

        try
        {
            casino.GetAccountBalance(player);
        }
        catch (NoSuchAccountException)
        {
            Assert.True(false);
        }
    }

    [Fact]
    public void TestDebit()
    {
        var casino = new Casino();
        
        var player = new Player();
        casino.CreateAccount(player);

        const decimal testAmount = 100;
        casino.Debit(player, testAmount);
        
        Assert.Equal(casino.InitialBalance - testAmount, casino.GetAccountBalance(player));
    }

    [Fact]
    public void TestCredit()
    {
        var casino = new Casino();
        
        var player = new Player();
        casino.CreateAccount(player);

        const decimal testAmount = 100;
        casino.Credit(player, testAmount);
        
        Assert.Equal(casino.InitialBalance + testAmount, casino.GetAccountBalance(player));
    }

    [Fact]
    public void TestMakeBet()
    {
        var casino = new Casino();
        
        var player = new Player();
        casino.CreateAccount(player);

        const decimal testAmount = 100;
        casino.MakeBet(player, testAmount);
        
        Assert.Equal(casino.InitialBalance - testAmount, casino.GetAccountBalance(player));
        Assert.Equal(testAmount, casino.GetAccountBet(player));
    }
}