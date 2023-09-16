﻿using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;

namespace WebAPI.Mapping
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			CreateMap<CreateTravelDto, Travel>().ReverseMap();
			CreateMap<ResultTravelDto, Travel>().ReverseMap();
		}
	}
}
