using System;
namespace Domain.Exceptions
{
    [Serializable()]
    public class ProjectUserException : Exception
    {
        public ProjectUserException() : base() { }
        public ProjectUserException(string message) : base(message) { }
        public ProjectUserException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected ProjectUserException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
