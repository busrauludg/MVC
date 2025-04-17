using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace StoreApp.Infrastructe.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();//ProductDto ortak olan listeler direak porudct erişilebilcek
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();//ProductDto ortak olan listeler direak porudct erişilebilcek

        }
    }
}
