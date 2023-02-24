using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.DTO;
using DataAccessLayer.NewFolder;
using System.Runtime.CompilerServices;

namespace ECommerceWebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDto, Category>()
                   .ForMember(d => d.Name, opt => opt.MapFrom(src => src.CategoryName)).ReverseMap();
            
            CreateMap<ProductDto, Product>()
                   .ForMember(d => d.ProductName, opt => opt.MapFrom(src => src.Name))
                   .ReverseMap();



            CreateMap<RoleRespDto, Role>();
           // .ForMember(d => d.ProductName, opt => opt.MapFrom(src => src.Name)).ReverseMap();
           
            CreateMap<UserDto, User>()
            .ForMember(d => d.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.Name)).ReverseMap();
            

        }
    }
}
