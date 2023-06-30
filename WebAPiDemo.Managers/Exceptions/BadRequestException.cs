using System;

namespace WebAPiDemo.Domain.Exceptions;
public abstract class BadRequestException : Exception
{
    protected BadRequestException(string message)
        : base(message)
    {
    }

    public BadRequestException() : base()
    {
    }

    public BadRequestException(string message, Exception innerException) : base(message, innerException)
    {
    }
}