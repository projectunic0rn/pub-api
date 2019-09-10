using System;
namespace Domain.Exceptions
{
    [Serializable()]
    public class AuthenticationException : Exception
    {
        public AuthenticationException() : base() { }
        public AuthenticationException(string message) : base(message) { }
        public AuthenticationException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected AuthenticationException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
