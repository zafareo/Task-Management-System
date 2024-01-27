﻿namespace Application.Commons.Exceptions;

public class AlreadyExistsException : Exception
{
    public AlreadyExistsException()
        : base() { }

    public AlreadyExistsException(string name, string key)
        : base($"Entity \"{name}\" ({key}) already exists") { }
}
