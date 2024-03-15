using OOP_ICT.EnumCard;

namespace OOP_ICT.Models;

public class Card
{
    public Ranks Rank { get; }
    public Suites Suit { get; }

    public Card(Ranks rank, Suites suit)
    {
        Rank = rank;
        Suit = suit;
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}