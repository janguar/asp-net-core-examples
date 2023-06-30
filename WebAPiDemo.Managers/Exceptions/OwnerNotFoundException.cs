using System;

namespace WebAPiDemo.Domain.Exceptions;

public sealed class OwnerNotFoundException : NotFoundException
{
    public OwnerNotFoundException(Guid ownerId)
        : base($"The owner with the identifier {ownerId} was not found.")
    {
    }

    private OwnerNotFoundException(string message) : base(message)
    {
    }

    public OwnerNotFoundException() : base()
    {
    }

    public OwnerNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}




