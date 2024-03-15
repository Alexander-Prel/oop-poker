using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Combinations.Checks;

public class FullHouse : Check
{
    public override bool _findCombination(List<Card> cards)
    {
        Name = Combination.FullHouse;
        return cards.GroupBy(card => card.Rank).Any(group => group.Count() == 3) && cards.GroupBy(card => card.Rank).Any(group => group.Count() == 2);
    }
}