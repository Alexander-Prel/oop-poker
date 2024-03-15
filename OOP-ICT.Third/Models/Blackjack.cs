using OOP_ICT.EnumCard;
using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using OOP_ICT.Third.Exceptions;

namespace OOP_ICT.Third.Models;

public class Blackjack
{
    private readonly BlackjackDealer _dealer;
    private readonly BlackjackCasino _casino;

    public List<Player> Players = new();

    private const int MaxScore = 21;
    private const int Modifier = 2;


    public Blackjack(BlackjackDealer dealer, BlackjackCasino casino)
    {
        _dealer = dealer;
        _casino = casino;
    }

    public void AddPlayer(Player player)
    {
        if (Players.Contains(player))
        {
            throw new PlayerAlreadyInGameException();
        }

        Players.Add(player);
    }

    public void Start()
    {
        if (Players.Any(player => _casino.GetAccountBet(player) == 0m))
        {
            throw new NoBetException();
        }

        foreach (var player in Players)
        {
            player.AddCard(_dealer.GiveCard());
            player.AddCard(_dealer.GiveCard());
        }

        _dealer.AddCard(_dealer.GiveCard());

        foreach (var player in from player in Players
                 let isBlackjack = _casino.PayIfBlackjack(player)
                 where isBlackjack
                 select player)
        {
            Players.Remove(player);
        }
    }

    public void DealerCards()
    {
        while (GetHandScore(_dealer.Cards) < 17)
        {
            _dealer.AddCard(_dealer.GiveCard());
        }
    }

    public void PlayerCard(Player player)
    {
        if (GetHandScore(player.Cards) >= MaxScore)
        {
            throw new BustedException();
        }
    }

    public static uint GetHandScore(IEnumerable<Card> cards)
    {
        uint score = 0;
        uint aceCount = 0;

        foreach (var card in cards)
        {
            switch (card.Rank)
            {
                case >= Ranks.Two and <= Ranks.Ten:
                    score += (uint)card.Rank;
                    break;
                case <= Ranks.King:
                    score += 10;
                    break;
                case Ranks.Ace:
                    aceCount++;
                    break;
            }
        }

        for (var i = 0; i < aceCount; i++)
        {
            if (score + 11 <= 21)
            {
                score += 11;
            }
            else
            {
                score += 1;
            }
        }

        return score;
    }


    public void End()
    {
        foreach (var player in Players)
        {
            if (GetHandScore(player.Cards) > GetHandScore(_dealer.Cards))
            {
                _casino.Credit(player, _casino.GetAccountBet(player) * Modifier);
            }
            else
            {
                _casino.ClearBet(player);
            }
        }
    }
}