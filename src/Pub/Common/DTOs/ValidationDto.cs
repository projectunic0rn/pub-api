namespace Common.DTOs
{
    public class ValidationDto
    {
        public ValidationDto()
        {
        }
        
        public ValidationDto(bool valid)
        {
            Valid = valid;
        }

        public ValidationDto(bool valid, string reason)
        {
            Valid = valid;
            Reason = reason;
        }

        public bool Valid;
        public string Reason;
    }
}
