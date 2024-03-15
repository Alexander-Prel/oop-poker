namespace OOP_ICT.Third.Exceptions;

public class NoBetException : Exception
{
    public NoBetException(string message = "Game can't be started") : base(message)
    {
    }
}