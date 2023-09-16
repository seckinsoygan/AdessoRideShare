using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = travelService.GetAll();
            return Ok(result);
        }
        [HttpGet("FromWhereToWhere")]
        public IActionResult GetTravel(string where, string to)
        {
            var result = travelService.GetAll().Where(x => x.FromWhere == where && x.FromTo == to).ToList();
            return Ok(mapper.Map<List<WhereToWhereDto>>(result));
        }
        [HttpPost("AddTravel")]
        public IActionResult Add(CreateTravelDto traveldto)
        {
            traveldto.TravelStatus = true;
            var value = mapper.Map<Travel>(traveldto);
            travelService.Add(value);
            return Ok("Travel added successfully");
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
