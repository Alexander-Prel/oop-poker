namespace OOP_ICT.Fourth.Exceptions;

public class PlayerAlreadyInGameException : Exception
{
    public PlayerAlreadyInGameException(string message = "PLayer is already in game") : base(message)
    {
    }
}