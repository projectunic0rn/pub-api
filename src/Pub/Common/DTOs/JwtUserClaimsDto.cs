namespace Common.DTOs
{
    public class JwtUserClaimsDto
    {
        public JwtUserClaimsDto(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
