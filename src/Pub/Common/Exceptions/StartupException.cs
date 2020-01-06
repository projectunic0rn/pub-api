using System;
namespace Common.Exceptions
{
    [Serializable()]
    public class StartupException : Exception
    {
        public StartupException() : base() { }
        public StartupException(string message) : base(message) { }
        public StartupException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected StartupException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
