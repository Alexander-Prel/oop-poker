namespace OOP_ICT.Second.Exceptions;

public class NoSuchAccountException : Exception
{
    public NoSuchAccountException(string message) : base(message)
    {
    }
}