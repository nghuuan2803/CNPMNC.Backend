using WMS.Application.DTOs.Requests.Account;
using WMS.Application.DTOs.Responses;
using WMS.Application.DTOs.Responses.Account;

namespace WMS.Application.Interfaces
{
    public interface IAccountService
    {
        Task CreateAdminAsync();
        Task<GeneralResponse> CreateAccountAsync(CreateAccountDTO model);
        Task<EmployeeLoginResponse> LoginAsync(LoginDTO model);
        Task<AgencyLoginResponse> AgencyLoginAsync(LoginDTO model);
        Task<GeneralResponse> CreateRoleAsync(CreateRoleDTO model);
        Task<IEnumerable<GetRoleDTO>> GetRolesAsync();
        Task<IEnumerable<GetUsersWithRoleDTO>> GetUsersWithRolesAsync();
        Task<GeneralResponse> ChangeUserRoleAsync(ChangeUserRoleDTO model);
        Task<LoginResponse> RefreshTokenAsync(RefreshTokenDTO model);
        Task<EmployeeLoginResponse> LoginByRfid(string rfid);
        Task LogOut();
    }
}
