namespace Domain.Exceptions
{
    public static class ExceptionMessage
    {
        // Errors on Authentication 
        public static string NonMatchingPasswords { get; } = "Passwords don't match";
        public static string InvalidCredentials { get; } = "Invalid username or password";
        // Error on Project Created
        public static string InvalidProjectType { get; } = "Invalid project type.";
        public static string InvalidCommunicationPlatform { get; } = "Invalid communication platform - supported platforms include ";
        
        // EF Core/Database Exceptions
        public static string UniquenessConstraintViolation { get; } = "Value violates uniqueness constraint";
        
        // Unknown Exception
        public static string ExceptionThrown { get; } = "Exception has been thrown.";
    }
}
