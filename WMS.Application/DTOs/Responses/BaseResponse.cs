namespace WMS.Application.DTOs.Responses
{
    public class BaseResponse<TData> where TData : class
    {
        public string? Message { get; set; }
        public TData ?Data { get; set; }
        public BaseResponse(TData data = null!, string message = null!)
        {
            Data = data;
            Message = message;
        }
    }
    public class BaseResponse
    {
        public string? Message { get; set; }
        public BaseResponse(string message = null!)
        {
            Message = message;
        }
    }
}
