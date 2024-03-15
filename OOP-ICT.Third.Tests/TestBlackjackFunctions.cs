using OOP_ICT.EnumCard;
using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using OOP_ICT.Third.Exceptions;
using OOP_ICT.Third.Models;
using Xunit;

namespace OOP_ICT.Third.Tests;

public class TestBlackjackFunctions
{
    [Fact]
    public void TestAddPlayer()
    {
        var deck = new CardDeck();
        var dealerPlayer = new Player();
        var dealer = new BlackjackDealer(deck, dealerPlayer);
        var casino = new BlackjackCasino();
        var blackjack = new Blackjack(dealer, casino);
        var player = new Player();
        
        blackjack.AddPlayer(player);
        
        Assert.Single(blackjack.Players);
        Assert.Contains(player, blackjack.Players);
    }

    [Fact]
    public void TestStartWithNoBet()
    {
        var deck = new CardDeck();
        var dealerPlayer = new Player();
        var dealer = new BlackjackDealer(deck, dealerPlayer);
        var casino = new BlackjackCasino();
        var blackjack = new Blackjack(dealer, casino);
        var player = new Player();
        blackjack.AddPlayer(player);
        casino.CreateAccount(player);
        
        Assert.Throws<NoBetException>(() => blackjack.Start());
    }

    [Fact]
    public void TestStartGame()
    {
        var deck = new CardDeck();
        var dealerPlayer = new Player();
        var dealer = new BlackjackDealer(deck, dealerPlayer);
        var casino = new BlackjackCasino();
        var blackjack = new Blackjack(dealer, casino);
        var player = new Player();
        
        casino.CreateAccount(player);
        
        const decimal bet = 10m;
        
        casino.MakeBet(player, bet);
        blackjack.AddPlayer(player);
        
        blackjack.Start();

        Assert.Equal(2, player.Cards.Count);
        Assert.Equal(1, dealer.Cards.Count);
    }

    [Fact]
    public void TestPlayerBust()
    {
        var deck = new CardDeck();
        var dealerPlayer = new Player();
        var dealer = new BlackjackDealer(deck, dealerPlayer);
        var casino = new BlackjackCasino();
        var blackjack = new Blackjack(dealer, casino);
        var player = new Player();
        casino.CreateAccount(player);
        
        const decimal bet = 10m;
        
        casino.MakeBet(player, bet);
        blackjack.AddPlayer(player);
        
        blackjack.Start();
        
        player.AddCard(new Card(Ranks.King, Suites.Clubs));
        player.AddCard(new Card(Ranks.King, Suites.Hearts));

        
        Assert.Throws<BustedException>(() => blackjack.PlayerCard(player));
    }

    [Fact]
    public void TestEndGame()
    {
        var deck = new CardDeck();
        var dealerPlayer = new Player();
        var dealer = new BlackjackDealer(deck, dealerPlayer);
        var casino = new BlackjackCasino();
        var blackjack = new Blackjack(dealer, casino);
        var player = new Player();
        casino.CreateAccount(player);
        
        const decimal bet = 10m;
        
        casino.MakeBet(player, bet);
        blackjack.AddPlayer(player);
        
        blackjack.Start();
        
        dealer.AddCard(new Card(Ranks.Ace, Suites.Spades));
        dealer.AddCard(new Card(Ranks.Ten, Suites.Hearts));
        player.AddCard(new Card(Ranks.Eight, Suites.Diamonds));
        player.AddCard(new Card(Ranks.Seven, Suites.Clubs));

        blackjack.End();

        Assert.Contains(casino.GetAccountBalance(player), new List<decimal>{90m, 110m});
    }
}