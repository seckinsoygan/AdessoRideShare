using Entities.Dtos.Travel;

namespace Entities.Dtos.Passenger
{
	public class ResultPassengerDto
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public ResultTravelDto TravelInfo { get; set; }
	}
}
