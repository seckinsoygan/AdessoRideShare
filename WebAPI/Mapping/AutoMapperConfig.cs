using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;

namespace WebAPI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<WhereToWhereDto, Travel>().ReverseMap();
            CreateMap<CreateTravelDto, Travel>().ReverseMap();
        }
    }
}
