using AutoMapper;
using WMS.Application.DTOs.Requests.Activities;
using WMS.Application.DTOs.Requests.Loacations;
using WMS.Application.DTOs.Requests.Organization;
using WMS.Application.DTOs.Requests.ProductGroup;
using WMS.Domain.Entities.Activities;
using WMS.Domain.Entities.Locations;
using WMS.Domain.Entities.Organization;
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
            CreateMap<Agency, AgencyDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Warehouse, WarehouseDTO>().ReverseMap();

            //// Map ImportDTO to Import (Entity)
            //CreateMap<ImportDTO, Import>()
            //    .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items)) // Mapping Import Items
            //    .ForMember(dest => dest.Manager, opt => opt.Ignore()) // Optional: Ignore Manager if not needed
            //    .ForMember(dest => dest.Suplier, opt => opt.Ignore()) // Optional: Ignore Suplier if not needed
            //    .ForMember(dest => dest.Warehouse, opt => opt.Ignore()); // Optional: Ignore Warehouse if not needed

            //// Map Import (Entity) to ImportDTO
            //CreateMap<Import, ImportDTO>()
            //    .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            //// Map ImportItem to ImportDetail
            //CreateMap<ImportItem, ImportDetail>()
            //    .ForMember(dest => dest.ImportId, opt => opt.MapFrom(src => src.ImportId))
            //    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));

            //// Map ImportDetail to ImportItem
            //CreateMap<ImportDetail, ImportItem>()
            //    .ForMember(dest => dest.ImportId, opt => opt.MapFrom(src => src.ImportId))
            //    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));

            CreateMap<Import, ImportDTO>()
            .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.Name))
            .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => $"{src.Manager.FirstName} {src.Manager.LastName}"))
            .ForMember(dest => dest.SuplierName, opt => opt.MapFrom(src => src.Suplier.Name))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items)); // Map danh sách Items

            // Mapping từ ImportDetail sang ImportItem
            CreateMap<ImportDetail, ImportItem>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name)) // Map ProductName từ Product
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Product.Photo));     // Map Photo từ Product

            // Mapping ngược từ DTO sang Entity (nếu cần)
            CreateMap<ImportDTO, Import>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items)); // Map danh sách Items

            CreateMap<ImportItem, ImportDetail>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId)) // Map ProductId từ ImportItem
                .ForMember(dest => dest.ImportId, opt => opt.MapFrom(src => src.ImportId))     
                .ForMember(dest => dest.Product, opt => opt.Ignore())                        // Bỏ qua Product để tránh map không mong muốn
                .ForMember(dest => dest.Import, opt => opt.Ignore());

        }
    }
}
