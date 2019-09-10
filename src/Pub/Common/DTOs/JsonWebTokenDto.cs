namespace Common.DTOs
{
    public class JsonWebTokenDto
    {
        public string Token { get; set; }

        public JsonWebTokenDto(string token)
        {
            Token = token;
        }
    }
}
