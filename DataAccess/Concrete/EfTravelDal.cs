using DataAccess.Abstract;
using DataAccess.Shared;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfTravelDal : ITravelDal
    {
        private readonly AppDbContext appDbContext;

        public EfTravelDal(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void Add(Travel travel)
        {
            appDbContext.Add(travel);
            appDbContext.SaveChanges();
        }

        public void Delete(Travel travel)
        {
            appDbContext.Remove(travel);
            appDbContext.SaveChanges();
        }

        public List<Travel> GetAll()
        {
            return appDbContext.Travels.ToList();
        }

        public Travel GetById(int id)
        {
            return appDbContext.Travels.Find(id);
        }

        public void Update(Travel travel)
        {
            appDbContext.Update(travel);
            appDbContext.SaveChanges();
        }
    }
}
