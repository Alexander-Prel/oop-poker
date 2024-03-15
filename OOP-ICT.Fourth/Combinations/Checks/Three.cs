using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Combinations.Checks;

public class Three : Check
{
    public override bool _findCombination(List<Card> cards)
    {
        Name = Combination.Three;
        return cards.GroupBy(card => card.Rank).Any(group => group.Count() == 3);
    }
}