using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Combinations.Checks;

public class Pair : Check
{
    public override bool _findCombination(List<Card> cards)
    {
        Name = Combination.Pair;
        return cards.GroupBy(card => card.Rank).Any(group => group.Count() == 2);
    }
}