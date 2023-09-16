using AutoMapper;
using Business.Abstract;
using Business.ValidationRules;
using Entities.Concrete;
using Entities.Dtos.Travel;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TravelController : ControllerBase
	{
		private readonly ITravelService travelService;
		private readonly IMapper mapper;

		public TravelController(ITravelService travelService, IMapper mapper)
		{
			this.travelService = travelService;
			this.mapper = mapper;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = mapper.Map<List<ResultTravelDto>>(travelService.GetAll());
			return Ok(result);
		}

		[HttpGet("FromWhereToWhere")]
		public IActionResult GetTravel(string where, string to)
		{
			var result = travelService.GetAll().Where(x => x.FromWhere == where && x.FromTo == to && x.TravelStatus == true).ToList(); //Travel Status boş koltuk olup olmama durumuna göre dönen değer.
			return Ok(mapper.Map<List<ResultTravelDto>>(result));
		}

		[HttpPost("AddTravel")]
		public IActionResult Add(CreateTravelDto traveldto)
		{
			var validator = new TravelValidator();
			var result = validator.Validate(traveldto);

			if (result.IsValid)
			{
				traveldto.TravelStatus = true;
				var value = mapper.Map<Travel>(traveldto);
				value.PassengerCount = 0;
				travelService.Add(value);
				return Ok("Travel added successfully");
			}
			else
			{
				var errors = result.Errors;
				var errorMessages = errors.Select(e => e.ErrorMessage).ToList();
				var response = new { errors = errorMessages };

				return BadRequest(response);
			}
		}

		[HttpDelete("DeleteTravel")]
		public IActionResult Delete(int id)
		{
			var value = travelService.GetById(id);
			travelService.Delete(value);
			return Ok("Travel deleted successfully");
		}
	}
}
