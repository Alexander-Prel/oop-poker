using OOP_ICT.EnumCard;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Combinations.Checks;

public class RoyalFlush : Check
{
    public override bool _findCombination(List<Card> cards)
    {
        Name = Combination.RoyalFlush;
        return new StraightFlush()._findCombination(cards) && cards.Any(card => card.Rank == Ranks.Ace);
    }
}