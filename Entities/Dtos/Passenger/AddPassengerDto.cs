namespace Entities.Dtos.Passenger
{
	public class AddPassengerDto
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string FromWhere { get; set; }
		public string FromTo { get; set; }
		public DateTime Date { get; set; }
	}
}
