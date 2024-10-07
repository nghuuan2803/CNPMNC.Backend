using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WMS.Application.DTOs.Responses;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Interfaces
{
    public interface IBrandService : IBaseService<Brand, int>
    {
    }
}
