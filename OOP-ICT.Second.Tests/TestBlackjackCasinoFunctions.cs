using OOP_ICT.EnumCard;
using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Second.Tests;

public class TestBlackjackCasinoFunctions
{
    [Fact]
    public void TestCheckForBlackjack()
    {
        var player = new Player();
        
        player.AddCard(new Card(Ranks.Ace, Suites.Clubs));
        player.AddCard(new Card(Ranks.King, Suites.Diamonds));
        
        Assert.True(BlackjackCasino.CheckForBlackjack(player));
    }

    [Fact]
    public void TestPayIfBlackjack()
    {
        var player = new Player();
        
        var casino = new BlackjackCasino();
        casino.CreateAccount(player);

        const decimal testAmount = 100m;
        
        casino.MakeBet(player, testAmount);
        
        player.AddCard(new Card(Ranks.Ace, Suites.Clubs));
        player.AddCard(new Card(Ranks.King, Suites.Diamonds));

        casino.PayIfBlackjack(player);
        
        Assert.Equal(casino.InitialBalance + testAmount * 0.5m, casino.GetAccountBalance(player));
    }
}