using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.Passenger;
using Entities.Concrete;
using Entities.Dtos.Passenger;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PassengerController : ControllerBase
	{
		private readonly IPassengerService passengerService;
		private readonly ITravelService travelService;
		private readonly IMapper mapper;

		public PassengerController(IPassengerService passengerService, ITravelService travelService, IMapper mapper)
		{
			this.passengerService = passengerService;
			this.travelService = travelService;
			this.mapper = mapper;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = mapper.Map<List<ResultPassengerDto>>(passengerService.GetAll());
			return Ok(result);
		}
		[HttpGet("GetById")]
		public IActionResult GetById(int id)
		{
			var result = mapper.Map<ResultPassengerDto>(passengerService.GetById(id));
			return Ok(result);
		}

		[HttpPost("Add")]
		public IActionResult AddPassenger(AddPassengerDto dto)
		{
			var validator = new PassengerValidator();
			var validatoresult = validator.Validate(dto);

			if (validatoresult.IsValid)
			{
				var travelinfo = travelService.GetAll().Where(x => x.FromWhere == dto.FromWhere && x.FromTo == dto.FromTo && x.TravelStatus == true && x.Date == dto.Date).FirstOrDefault();
				if (travelinfo != null)
				{
					var passenger = new Passenger();
					passenger.Name = dto.Name;
					passenger.Surname = dto.Surname;
					passenger.TravelId = travelinfo.TravelId;
					passenger.TravelInfo = travelinfo;
					passengerService.Add(passenger);
					travelinfo.PassengerCount += 1;
					if (travelinfo.PassengerCount == travelinfo.SeatCount)
					{
						travelinfo.TravelStatus = false;
					}
					travelService.Update(travelinfo);
					return Ok("Passenger successfully added. Trip information saved.");
				}
				return BadRequest("No trips for this information were found.");
			}
			else
			{
				var errors = validatoresult.Errors;
				var errorMessages = errors.Select(e => e.ErrorMessage).ToList();
				var response = new { errors = errorMessages };

				return BadRequest(response);
			}
		}
		[HttpDelete("Delete")]
		public IActionResult DeletePassenger(int id)
		{
			var passenger = passengerService.GetById(id);
			var travel = travelService.GetById(passenger.TravelId);
			if (travel != null)
			{
				if (travel.TravelStatus == false)
				{
					travel.TravelStatus = true;
				}
				travel.PassengerCount -= 1;
				travelService.Update(travel);
			}
			passengerService.Delete(passenger);
			return Ok("Passenger deleted successfully");
		}
	}
}
