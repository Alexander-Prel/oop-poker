using OOP_ICT.EnumCard;

namespace OOP_ICT.Models;

public class CardDeck
{
    public readonly List<Card> Cards = new();

    public CardDeck()
    {
        CreateDeck();
    }
    
    private void CreateDeck()
    {
        foreach (Ranks rank in Enum.GetValues(typeof(Ranks)))
        {
            foreach (Suites suit in Enum.GetValues(typeof(Suites)))
            {
                Cards.Add(new Card(rank, suit));
            }
        }
    }
}