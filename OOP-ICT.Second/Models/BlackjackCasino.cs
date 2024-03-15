using OOP_ICT.EnumCard;
using OOP_ICT.Models;

namespace OOP_ICT.Second.Models;

public class BlackjackCasino : Casino
{
    public decimal BlackjackModifier { get; set; } = 1.5m;

    public static bool CheckForBlackjack(Player player)
    {
        var cardsList = player.Cards.ToList();
        if (cardsList.Count != 2)
        {
            return false;
        }

        var firstCard = cardsList[0];
        var secondCard = cardsList[1];

        return cardsList.Any(x => x.Rank == Ranks.Ace) && cardsList.Any(x =>
            new List<Ranks> { Ranks.Ten, Ranks.Jack, Ranks.Queen, Ranks.King }.Contains(x.Rank));
    }

    public bool PayIfBlackjack(Player player)
    {
        var isBlackjack = CheckForBlackjack(player);
        if (isBlackjack)
        {
            Credit(player, BlackjackModifier * GetAccountBet(player));
        }

        return isBlackjack;
    }
}