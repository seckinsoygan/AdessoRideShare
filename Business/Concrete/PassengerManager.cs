using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class PassengerManager : IPassengerService
	{
		private readonly IPassengerDal passengerDal;

		public PassengerManager(IPassengerDal passengerDal)
		{
			this.passengerDal = passengerDal;
		}
		public void Add(Passenger passenger)
		{
			passengerDal.Add(passenger);
		}

		public void Delete(Passenger passenger)
		{
			passengerDal.Delete(passenger);
		}

		public List<Passenger> GetAll()
		{
			return passengerDal.GetAll();
		}

		public Passenger GetById(int id)
		{
			return passengerDal.GetById(id);
		}
	}
}
