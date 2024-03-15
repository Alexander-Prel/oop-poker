using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Combinations.Checks;

public class StraightFlush : Check
{
    public override bool _findCombination(List<Card> cards)
    {
        Name = Combination.StraightFlush;
        return new Straight()._findCombination(cards) && new Flush()._findCombination(cards);
    }
}