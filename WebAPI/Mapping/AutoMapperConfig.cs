using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Passenger;
using Entities.Dtos.Travel;

namespace WebAPI.Mapping
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			CreateMap<CreateTravelDto, Travel>().ReverseMap();
			CreateMap<ResultTravelDto, Travel>().ReverseMap();

			CreateMap<ResultPassengerDto, Passenger>().ReverseMap();
		}
	}
}
