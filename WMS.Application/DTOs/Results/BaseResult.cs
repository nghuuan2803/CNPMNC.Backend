namespace WMS.Application.DTOs.Results
{
    public class BaseResult<TData> where TData : class
    {
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public TData? Data { get; set; }

        public BaseResult(TData data = null!, bool succeeded = true, string message = null! )
        {
            Succeeded = succeeded;
            Message = message;
            Data = data;
        }
    }
    public class BaseResult
    {
        public bool Succeeded { get; set; }
        public string? Message { get; set; }

        public BaseResult(bool succeeded = true, string message = null!)
        {
            Succeeded = succeeded;
            Message = message;
        }
    }
}
