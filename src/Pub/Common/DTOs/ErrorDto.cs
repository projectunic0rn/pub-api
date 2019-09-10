namespace Common.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
        }

        public ErrorDto(string message)
        {
            Message = message;
        }

        
        public string Message {get;set;}
    }
}
