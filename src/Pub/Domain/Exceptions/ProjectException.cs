using System;
namespace Domain.Exceptions
{
    [Serializable()]
    public class ProjectException : Exception
    {
        public ProjectException() : base() { }
        public ProjectException(string message) : base(message) { }
        public ProjectException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected ProjectException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
