using AutoMapper;
using ProductStore.Core.DataModels;
using ProductStore.Shared.DTOs;
using ProductStore.Shared.DTOs.Models;
using System;

namespace ProductStore.BLL.Mapping
{
    class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<AddCustomerInDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerProduct, SaleReportDTO>();
            CreateMap<SellProductInDTO, CustomerProduct>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTimeOffset.UtcNow));

            CreateMap<CustomerProduct, CustomerProductDTO>();
            CreateMap<InputProductInDTO, Product>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Section, SectionDTO>();
            CreateMap<CreateSectionInDTO, Section>();
        }
    }
}
