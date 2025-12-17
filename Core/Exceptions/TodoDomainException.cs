using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Core.Exceptions
{
    public class TodoDomainException : Exception
    {
        public TodoDomainException()
        {

        }
        public TodoDomainException(string? message) : base(message)
        {

        }
        public TodoDomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
        protected TodoDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
