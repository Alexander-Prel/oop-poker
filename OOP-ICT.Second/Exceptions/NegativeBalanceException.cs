namespace OOP_ICT.Second.Exceptions;

public class NegativeBalanceException : Exception
{
    public NegativeBalanceException(string message = "Account balance can't be negative") : base(message)
    {
    }
}