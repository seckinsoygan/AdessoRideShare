namespace Entities.Concrete
{
	public class Passenger
	{
		public int PassengerId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public int TravelId { get; set; }
		public Travel TravelInfo { get; set; }
	}
}
