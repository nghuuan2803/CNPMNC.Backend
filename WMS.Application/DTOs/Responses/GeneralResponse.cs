namespace WMS.Application.DTOs.Responses
{
    public record GeneralResponse(bool Succeeded = false, string Message = null!);
}
