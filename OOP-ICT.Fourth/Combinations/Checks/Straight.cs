using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Combinations.Checks;

public class Straight : Check
{
    public override bool _findCombination(List<Card> cards)
    {
        Name = Combination.Straight;
        cards.Sort((card1, card2) => card1.Rank.CompareTo(card2.Rank));
        for (var i = 0; i < cards.Count - 1; i++)
        {
            if (cards[i].Rank + 1 != cards[i + 1].Rank)
            {
                return false;
            }
        }

        return true;
    }
}