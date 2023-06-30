using System;

namespace WebAPiDemo.Domain.Exceptions;

public abstract class NotFoundException : Exception
{
    protected NotFoundException(string message)
        : base(message)
    {
    }

    public NotFoundException() : base()
    {
    }

    public NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}




