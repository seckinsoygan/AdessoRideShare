using DataAccess.Abstract;
using DataAccess.Shared;
using Entities.Concrete;

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
			return appDbContext.Passengers.ToList();
		}

		public Passenger GetById(int id)
		{
			return appDbContext.Passengers.Find(id);
		}

		public void Update(Passenger passenger)
		{
			appDbContext.Update(passenger);
			appDbContext.SaveChanges();
		}
	}
}
