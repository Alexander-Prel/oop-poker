using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Combinations.Checks;

public class TwoPairs : Check
{
    public override bool _findCombination(List<Card> cards)
    {
        Name = Combination.TwoPairs;
        return cards.GroupBy(card => card.Rank).Count(group => group.Count() == 2) == 2;
    }
}