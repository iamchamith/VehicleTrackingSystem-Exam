﻿using System;

namespace Core.Utilities
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string message) : base(message)
        {
        }
    }
}
