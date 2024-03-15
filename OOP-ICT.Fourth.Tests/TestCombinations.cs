using OOP_ICT.EnumCard;
using OOP_ICT.Fourth.Combinations;
using OOP_ICT.Fourth.Models;
using OOP_ICT.Models;
using Xunit;

namespace OOP_ICT.Fourth.Tests;

public class CombinationFinderTests
{
    [Fact]
    public void TestRoyalFlush()
    {
        var cards = new List<Card>
        {
            new Card(Ranks.Ace, Suites.Hearts),
            new Card(Ranks.King, Suites.Hearts),
            new Card(Ranks.Queen, Suites.Hearts),
            new Card(Ranks.Jack, Suites.Hearts),
            new Card(Ranks.Ten, Suites.Hearts),
        };

        var result = CombinationFinder.Evaluate(cards);

        Assert.Equal(Combination.RoyalFlush, result);
    }

    [Fact]
    public void TestStraightFlush()
    {
        var cards = new List<Card>
        {
            new Card(Ranks.Ten, Suites.Hearts),
            new Card(Ranks.Nine, Suites.Hearts),
            new Card(Ranks.Eight, Suites.Hearts),
            new Card(Ranks.Seven, Suites.Hearts),
            new Card(Ranks.Six, Suites.Hearts),
        };

        var result = CombinationFinder.Evaluate(cards);

        Assert.Equal(Combination.StraightFlush, result);
    }

    [Fact]
    public void TestFour()
    {
        var cards = new List<Card>
        {
            new Card(Ranks.Ten, Suites.Hearts),
            new Card(Ranks.Ten, Suites.Diamonds),
            new Card(Ranks.Ten, Suites.Clubs),
            new Card(Ranks.Ten, Suites.Spades),
            new Card(Ranks.Six, Suites.Hearts),
        };

        var result = CombinationFinder.Evaluate(cards);

        Assert.Equal(Combination.Four, result);
    }

    [Fact]
    public void TestFullHouse()
    {
        var cards = new List<Card>
        {
            new Card(Ranks.Ten, Suites.Hearts),
            new Card(Ranks.Ten, Suites.Diamonds),
            new Card(Ranks.Ten, Suites.Clubs),
            new Card(Ranks.Six, Suites.Spades),
            new Card(Ranks.Six, Suites.Hearts),
        };

        var result = CombinationFinder.Evaluate(cards);

        Assert.Equal(Combination.FullHouse, result);
    }
    
    [Fact]
    public void TestFlush()
    {
        var cards = new List<Card>
        {
            new Card(Ranks.Ten, Suites.Hearts),
            new Card(Ranks.Nine, Suites.Hearts),
            new Card(Ranks.Eight, Suites.Hearts),
            new Card(Ranks.King, Suites.Hearts),
            new Card(Ranks.Six, Suites.Hearts),
        };

        var result = CombinationFinder.Evaluate(cards);

        Assert.Equal(Combination.Flush, result);
    }
    
    [Fact]
    public void TestStraight()
    {
        var cards = new List<Card>
        {
            new Card(Ranks.Ten, Suites.Hearts),
            new Card(Ranks.Nine, Suites.Diamonds),
            new Card(Ranks.Eight, Suites.Clubs),
            new Card(Ranks.Seven, Suites.Spades),
            new Card(Ranks.Six, Suites.Hearts),
        };

        var result = CombinationFinder.Evaluate(cards);

        Assert.Equal(Combination.Straight, result);
    }
    
    [Fact]
    public void TestThree()
    {
        var cards = new List<Card>
        {
            new Card(Ranks.Ten, Suites.Hearts),
            new Card(Ranks.Ten, Suites.Diamonds),
            new Card(Ranks.Ten, Suites.Clubs),
            new Card(Ranks.Seven, Suites.Spades),
            new Card(Ranks.Six, Suites.Hearts),
        };

        var result = CombinationFinder.Evaluate(cards);

        Assert.Equal(Combination.Three, result);
    }
    
    [Fact]
    public void TestTwoPairs()
    {
        var cards = new List<Card>
        {
            new Card(Ranks.Ten, Suites.Hearts),
            new Card(Ranks.Ten, Suites.Diamonds),
            new Card(Ranks.Seven, Suites.Clubs),
            new Card(Ranks.Seven, Suites.Spades),
            new Card(Ranks.Six, Suites.Hearts),
        };

        var result = CombinationFinder.Evaluate(cards);

        Assert.Equal(Combination.TwoPairs, result);
    }
    
    [Fact]
    public void TestPair()
    {
        var cards = new List<Card>
        {
            new Card(Ranks.Ten, Suites.Hearts),
            new Card(Ranks.Ten, Suites.Diamonds),
            new Card(Ranks.Nine, Suites.Clubs),
            new Card(Ranks.Seven, Suites.Spades),
            new Card(Ranks.Six, Suites.Hearts),
        };

        var result = CombinationFinder.Evaluate(cards);

        Assert.Equal(Combination.Pair, result);
    }
    
    [Fact]
    public void TestOldestCard()
    {
        var cards = new List<Card>
        {
            new Card(Ranks.Ten, Suites.Hearts),
            new Card(Ranks.Nine, Suites.Diamonds),
            new Card(Ranks.Eight, Suites.Clubs),
            new Card(Ranks.King, Suites.Spades),
            new Card(Ranks.Six, Suites.Hearts),
        };

        var result = CombinationFinder.Evaluate(cards);

        Assert.Equal(Combination.OldestCard, result);
    }
}