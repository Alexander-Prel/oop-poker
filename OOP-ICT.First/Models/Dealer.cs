namespace OOP_ICT.Models;

public class Dealer
{
    private readonly CardDeck _deck;
    public Stack<Card> ShuffledDeck { get; private set; } = new();

    public Dealer(CardDeck deck)
    {
        _deck = deck;
    }
    
    private IEnumerable<Card> Shuffle()
    {
        var shuffledDeck = _deck.Cards.OrderBy(_ => Guid.NewGuid()).ToList();
        return shuffledDeck;
    }
    
    public Card GiveCard()
    {
        if (ShuffledDeck.Count == 0)
            ShuffledDeck = new Stack<Card>(Shuffle());
        return ShuffledDeck.Pop();
    }
}
