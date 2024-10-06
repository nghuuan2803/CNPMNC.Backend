using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Application.Interfaces;
using WMS.Application.Services;
using WMS.Domain.Abstracts;
using WMS.Domain.Entities.Authentication;
using WMS.Infrastructure.Data;
using WMS.Infrastructure.Repositories;
using WMS.Infrastructure.SqlsvUnitOfwork;

namespace WMS.Infrastructure.DependencyInjection
{
    public static class LeHuyDI
    {
        public static void AddLeHuyDI(this IServiceCollection services, IConfiguration configuration)
        {
            // Đăng ký Repository và Service cho Supplier (Nhà cung cấp)
            services.AddScoped<ISuplierService, SuplierService>();
        }
    }
}
