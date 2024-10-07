using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Application.Interfaces;
using WMS.Application.Services;
using WMS.Domain.Abstracts.ProductRepo;
using WMS.Infrastructure.Repositories.ProductData;

namespace WMS.Infrastructure.DependencyInjection
{
    public static class GiaBaoDI
    {
        public static void AddGiaBaoDI(this IServiceCollection services, IConfiguration configuration)
        {
            //brand
            services.AddScoped<IBrandService, BrandService>();

        }
    }
}
