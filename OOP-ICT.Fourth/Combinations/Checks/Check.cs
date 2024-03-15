using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Combinations.Checks;

public abstract class Check
{
    public Combination Name;
    public Check NextCheck;
    
    public Combination FindCombination(IEnumerable<Card> cards)
    {
        var listCards = cards.ToList();
        if (_findCombination(listCards)) return Name;
        return NextCheck?.FindCombination(listCards) ?? new OldestCard().Name;
    }

    public abstract bool _findCombination(List<Card> cards);
}