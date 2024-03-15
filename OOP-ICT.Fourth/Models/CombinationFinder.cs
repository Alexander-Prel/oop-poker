using OOP_ICT.Fourth.Combinations;
using OOP_ICT.Fourth.Combinations.Checks;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models;

public class CombinationFinder
{
    public static Combination Evaluate(IEnumerable<Card> cards)
    {
        var checks = new List<Check>
        {
            new RoyalFlush(),
            new StraightFlush(),
            new Four(),
            new FullHouse(),
            new Flush(),
            new Straight(),
            new Three(),
            new TwoPairs(),
            new Pair(),
            new OldestCard()
        };

        for (var i = 0; i < checks.Count - 1; i++)
        {
            checks[i].NextCheck = checks[i + 1];
        }
        
        return checks.First().FindCombination(cards.ToList());
    }

}