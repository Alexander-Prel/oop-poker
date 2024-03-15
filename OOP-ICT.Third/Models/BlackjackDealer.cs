using System.Collections.Immutable;
using OOP_ICT.Models;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Third.Models;

public class BlackjackDealer : Dealer
{
    private readonly Player _cardholder;

    public BlackjackDealer(CardDeck deck, Player player) : base(deck)
    {
        _cardholder = player;
    }

    public void AddCard(Card card)
    {
        _cardholder.AddCard(card);
    }

    public ImmutableList<Card> Cards => _cardholder.Cards;
}