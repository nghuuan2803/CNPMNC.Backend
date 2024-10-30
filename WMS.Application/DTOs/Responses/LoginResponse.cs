namespace WMS.Application.DTOs.Responses
{
    public record LoginResponse(bool Succeeded = false, string Message = null!, string Token = null!, string RefreshToken = null!);
    public record AgencyLoginResponse(bool Succeeded = false, string Message = null!, string Token = null!, string RefreshToken = null!, int? AgencyId = null!);
    public record EmployeeLoginResponse(bool Succeeded = false, string Message = null!, string Token = null!, string RefreshToken = null!, string? EmployeeId = null!);
}
