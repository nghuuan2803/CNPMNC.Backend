using AutoMapper;
using WMS.Application.DTOs.Requests.ProductGroup;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.WebAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<SignUpModel, SignUpDTO>()
            //    .ForMember(dest => dest.NormalizeUsername, opt => opt.MapFrom(src => src.Username.ToUpper()))
            //    .ForMember(dest => dest.NormalizeEmail, opt => opt.MapFrom(src => src.Username.ToUpper()));

            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
