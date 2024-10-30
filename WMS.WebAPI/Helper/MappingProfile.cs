using AutoMapper;
using WMS.Application.DTOs;
using WMS.Application.DTOs.Requests;
using WMS.Application.DTOs.Requests.Activities;
using WMS.Application.DTOs.Requests.Loacations;
using WMS.Application.DTOs.Requests.Organization;
using WMS.Application.DTOs.Requests.ProductGroup;
using WMS.Domain.Entities.Activities;
using WMS.Domain.Entities.Locations;
using WMS.Domain.Entities.Organization;
using WMS.Domain.Entities.ProductGroup;
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

            CreateMap<Product, ProductDetails>().ReverseMap();
            CreateMap<Agency, AgencyDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            CreateMap<Warehouse, WarehouseDTO>()
                .ForMember(dest => dest.KeeperName, opt => opt.MapFrom(src => src.Manager.FirstName + " " + src.Manager.LastName));

            CreateMap<WarehouseDTO, Warehouse>();

            CreateMap<Suplier, SuplierDTO>().ReverseMap();
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Inventory, InventoryDTO>()
                .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.Name))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<InventoryDTO, Inventory>();

            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name));

            CreateMap<ProductDTO, Product>();

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

            CreateMap<Export, ExportDTO>()
            .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => $"{src.Manager.FirstName} {src.Manager.LastName}"))
            .ForMember(dest => dest.AgencyName, opt => opt.MapFrom(src => $"{src.Agency.Name}"))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items)); // Map danh sách Items

            // Mapping từ ImportDetail sang ImportItem
            CreateMap<ExportDetail, ExportItem>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name)) // Map ProductName từ Product
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Product.Photo))
                .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.Name));

            // Mapping ngược từ DTO sang Entity (nếu cần)
            CreateMap<ExportDTO, Export>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items)); // Map danh sách Items

            CreateMap<ExportItem, ExportDetail>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId)) // Map ProductId từ ImportItem
                .ForMember(dest => dest.ExportId, opt => opt.MapFrom(src => src.ExportId))
                .ForMember(dest => dest.Product, opt => opt.Ignore())                        // Bỏ qua Product để tránh map không mong muốn
                .ForMember(dest => dest.Export, opt => opt.Ignore());

            // Map từ OrderRequest sang Export
            CreateMap<OrderRequest, Export>()
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
                .ForMember(dest => dest.AgencyId, opt => opt.MapFrom(src => src.AgencyId))
                .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.ManagerId))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            // Map từ AddOrderItem sang ExportDetail
            CreateMap<AddOrderItem, ExportDetail>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<Item, ItemDTO>()
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Product.Photo))
                .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.Name))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<ScanAllResult, ScanDTO>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee))
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));

            CreateMap<Merge, MergeDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.FromWarehouse, opt => opt.MapFrom(src => src.Src.Name))
                .ForMember(dest => dest.ToWarehouse, opt => opt.MapFrom(src => src.Dest.Name));

            CreateMap<Notification, NotifyDTO>().ReverseMap();
        }
    }
}
