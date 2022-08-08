public class DomainException : Exception
{
    public DomainException(DomainExceptionType type, string? message) : this(type, message, null)
    { }

    public DomainException(DomainExceptionType type, string? message, Exception? innerException)
        : base(message, innerException)
    {
        Type = type;
    }

    public DomainExceptionType Type { get; }
}
