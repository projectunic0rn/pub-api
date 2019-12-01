namespace Common.DTOs
{
    public class RegistrationDto
    {
        
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string Locale { get; set; }
        public string Timezone { get; set; }
    }
}
