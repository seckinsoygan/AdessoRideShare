using Entities.Concrete;

namespace DataAccess.Abstract
{
	public interface IPassengerDal
	{
		List<Passenger> GetAll();
		Passenger GetById(int id);
		void Add(Passenger passenger);
		void Delete(Passenger passenger);
		void Update(Passenger passenger);
	}
}
