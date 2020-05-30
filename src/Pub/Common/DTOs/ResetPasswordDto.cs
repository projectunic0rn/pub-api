namespace Common.DTOs
{
    public class ResetPasswordDto
    {
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public string ValidationToken { get; set; }
    }
}
