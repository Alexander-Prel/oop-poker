using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Combinations.Checks;

public class Flush : Check
{
    public override bool _findCombination(List<Card> cards)
    {
        Name = Combination.Flush;
        return cards.GroupBy(card => card.Suit).Any(group => group.Count() == 5);
    }
}