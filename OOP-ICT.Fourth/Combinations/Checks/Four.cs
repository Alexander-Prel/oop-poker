using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Combinations.Checks;

public class Four : Check
{
    public override bool _findCombination(List<Card> cards)
    {
        Name = Combination.Four;
        return cards.GroupBy(card => card.Rank).Any(group => group.Count() == 4);
    }
}