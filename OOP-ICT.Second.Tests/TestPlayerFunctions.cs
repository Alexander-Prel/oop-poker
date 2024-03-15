using OOP_ICT.EnumCard;
using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Second.Tests;

public class TestPlayerFunctions
{
    [Fact]
    public void TestPlayersHand()
    {
        var player = new Player();
        var card = new Card(Ranks.Ace, Suites.Clubs);
        player.AddCard(card);
        
        Assert.Single(player.Cards);
        Assert.Contains(card, player.Cards);
    }
}