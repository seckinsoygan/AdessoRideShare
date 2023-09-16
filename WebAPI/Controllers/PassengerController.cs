﻿using Business.Abstract;
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

		public PassengerController(IPassengerService passengerService, ITravelService travelService)
		{
			this.passengerService = passengerService;
			this.travelService = travelService;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = passengerService.GetAll();
			return Ok(result);
		}
		[HttpGet("GetById")]
		public IActionResult GetById(int id)
		{
			var result = passengerService.GetById(id);
			return Ok(result);
		}

		[HttpPost("Add")]
		public IActionResult AddPassenger(AddPassengerDto dto)
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
		[HttpDelete]
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
