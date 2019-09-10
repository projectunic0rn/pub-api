namespace Common.DTOs
{
    public class ResponseDto<T>
    {
        public ResponseDto(bool ok)
        {
            Ok = ok;
        }
        public bool Ok { get; set; }
        public T Data { get; set; }
    }
}
