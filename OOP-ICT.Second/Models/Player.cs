using System.Collections.Immutable;
using OOP_ICT.Models;

namespace OOP_ICT.Second.Models;

public class Player
{
    public string Name { get; set; }
    
    private List<Card> _cards = new();
    public ImmutableList<Card> Cards => _cards.ToImmutableList();
    
    public void AddCard(Card card)
    { 
        _cards.Add(card);
    }
}