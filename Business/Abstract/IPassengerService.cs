using Entities.Concrete;

namespace Business.Abstract
{
	public interface IPassengerService
	{
		List<Passenger> GetAll();
		Passenger GetById(int id);
		void Add(Passenger passenger);
		void Delete(Passenger passenger);
	}
}
