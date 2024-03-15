namespace OOP_ICT.Third.Exceptions;

public class BustedException : Exception
{
    public BustedException(string message = "Player can't take a card") : base(message)
    {
    }
}