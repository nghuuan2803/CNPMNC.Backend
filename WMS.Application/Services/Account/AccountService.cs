using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WMS.Application.DTOs.Requests.Account;
using WMS.Application.DTOs.Responses;
using WMS.Application.DTOs.Responses.Account;
using WMS.Application.Interfaces;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Authentication;

namespace WMS.Application.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;            
        }
        public Task<GeneralResponse> ChangeUserRoleAsync(ChangeUserRoleDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse> CreateAccountAsync(CreateAccountDTO model)
        {
            throw new NotImplementedException();
        }

        public Task CreateAdminAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse> CreateRoleAsync(CreateRoleDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetRoleDTO>> GetRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetUsersWithRoleDTO>> GetUsersWithRolesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeLoginResponse> LoginAsync(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {               
                return new EmployeeLoginResponse(Message: "Tài khoản không tồn tại!");
            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return new EmployeeLoginResponse(Message: "Mật khẩu không chính xác!");
            }
            var token = await CreateTokenAsync(user);
            return new EmployeeLoginResponse(Message: "Đăng nhập thành công!",Token: token,Succeeded:true, EmployeeId: user.EmployeeId);
        }

        public async Task<AgencyLoginResponse> AgencyLoginAsync(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new AgencyLoginResponse(Message: "Tài khoản không tồn tại!");
            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return new AgencyLoginResponse(Message: "Mật khẩu không chính xác!");
            }
            var token = await CreateTokenAsync(user);
            return new AgencyLoginResponse(Message: "Đăng nhập thành công!", Token: token, Succeeded: true, AgencyId: user.AgencyId);
        }

        public Task LogOut()
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponse> RefreshTokenAsync(RefreshTokenDTO model)
        {
            throw new NotImplementedException();
        }


        private async Task<string> CreateTokenAsync(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            }.Union(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddMinutes(int.Parse(_configuration["JWT:Expire"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256Signature)
                );
            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenHandler;
        }

        public Task<EmployeeLoginResponse> LoginByRfid(string rfid)
        {
            throw new NotImplementedException();
        }
    }
}
