using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Combinations.Checks;

public class OldestCard : Check
{
    public override bool _findCombination(List<Card> cards)
    {
        Name = Combination.OldestCard;
        return true;
    }
}