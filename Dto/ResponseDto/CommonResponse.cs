namespace Portfolio.Dto.ResponseDto
{
    public class CommonResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public CommonResponse(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }
}
}
