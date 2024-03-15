namespace OOP_ICT.Third.Exceptions;

public class PlayerAlreadyInGameException : Exception
{
    public PlayerAlreadyInGameException(string message = "Player is already in game") : base(message)
    {
    }
}