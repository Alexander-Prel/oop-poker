namespace OOP_ICT.Fourth.Exceptions;

public class NotEnoughPlayersException : Exception
{
    public NotEnoughPlayersException(string message = "Too few players to start the game") : base(message)
    {
    }
}