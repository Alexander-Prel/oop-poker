using OOP_ICT.Fourth.Combinations;
using OOP_ICT.Fourth.Exceptions;
using OOP_ICT.Models;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Models;

public class Poker
{
    private readonly Casino _casino;
    private readonly Dealer _dealer;
    
    public List<Player> Players = new();

    private decimal _maxBet;
    
    private int _smallBlindIndex = 1;
    public Player SmallBlindPlayer { get; set; }
    
    public readonly decimal smallBlind = 5m;
    
    public List<Card> TableCards = new();

    public Poker(Casino casino, Dealer dealer)
    {
        _casino = casino;
        _dealer = dealer;
    }
    
    public void AddPlayer(Player player)
    {
        if (Players.Contains(player))
        {
            throw new PlayerAlreadyInGameException();
        }

        Players.Add(player);
    }
    
    public void MakeBet(Player player, decimal amount)
    {
        _casino.MakeBet(player, amount);
        var bet = _casino.GetAccountBet(player);
        if (bet > _maxBet)
        {
            _maxBet = bet;
        }
    }
    
    public void MakeBlinds()
    {
        _casino.MakeBet(SmallBlindPlayer, smallBlind);
        _smallBlindIndex += 1;
        var bigBlindPlayer = Players[_smallBlindIndex % Players.Count];
        _casino.MakeBet(bigBlindPlayer, smallBlind * 2);
    }

    public void Start()
    {
        if (Players.Count < 3)
        {
            throw new NotEnoughPlayersException();
        }
        
        MakeBlinds();
        
        foreach (var player in Players)
        {
            player.AddCard(_dealer.GiveCard());
            player.AddCard(_dealer.GiveCard());
        }
        
        for (var i = 0; i < 3; i++)
        {
            TableCards.Add(_dealer.GiveCard());
        }
    }
    
    public void AddCardToTable()
    {
        TableCards.Add(_dealer.GiveCard());
    }
    
    public void EndGame()
    {
        var winner = _getWinner();
        _casino.Credit(winner, Players.Sum(x => _casino.GetAccountBet(x)));
        foreach (var player in Players)
        {
            _casino.ClearBet(player);
        }
    }
    
    private Player _getWinner()
    {
        var winner = Players[0];
        var bestCombination = Combination.OldestCard;

        foreach (var player in Players)
        {
            var combination = CombinationFinder.Evaluate(player.Cards.AddRange(TableCards));
            if (player == Players[0])
            {
                bestCombination = combination;
                winner = player;
            }
            else
            {
                if (combination.CompareTo(bestCombination) <= 0) continue;
                bestCombination = combination;
                winner = player;
            }
        }

        return winner;
    }
}