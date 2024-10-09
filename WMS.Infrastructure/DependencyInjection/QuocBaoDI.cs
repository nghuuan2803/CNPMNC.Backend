using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WMS.Application.Interfaces;
using WMS.Application.Services.ProductGroup;

namespace WMS.Infrastructure.DependencyInjection
{
    public static class QuocBaoDI
    {
        public static void AddQuocBaoDI(this IServiceCollection services, IConfiguration configuration)
        {
            //batch, origin , product
            services.AddScoped<IBatchService, BatchService>();
        }
    }
}
