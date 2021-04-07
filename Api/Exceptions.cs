using System;

namespace Api
{
    public class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException(string message = "") : base(message)
        {

        }
    }
}
