using DataAccess.Abstract;
using DataAccess.Shared;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
	public class EfPassengerDal : IPassengerDal
	{
		private readonly AppDbContext appDbContext;

		public EfPassengerDal(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public void Add(Passenger passenger)
		{
			appDbContext.Add(passenger);
			appDbContext.SaveChanges();
		}

		public void Delete(Passenger passenger)
		{
			appDbContext.Remove(passenger);
			appDbContext.SaveChanges();
		}

		public List<Passenger> GetAll()
		{
			return appDbContext.Passengers.Include(x => x.TravelInfo).ToList();
		}

		public Passenger GetById(int id)
		{
			return appDbContext.Passengers.Include(x => x.TravelInfo).SingleOrDefault(x => x.PassengerId == id);
		}

		public void Update(Passenger passenger)
		{
			appDbContext.Update(passenger);
			appDbContext.SaveChanges();
		}
	}
}
