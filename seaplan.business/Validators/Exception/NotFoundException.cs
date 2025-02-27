namespace seaplan.business.Validators;

public class NotFoundException : Exception
{
    public NotFoundException() : base("Values is not  found")
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string message, Exception? exception) : base(message, exception)
    {
    }
}