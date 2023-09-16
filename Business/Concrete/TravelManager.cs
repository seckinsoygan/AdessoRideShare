using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TravelManager : ITravelService
    {
        private readonly ITravelDal travelDal;

        public TravelManager(ITravelDal travelDal)
        {
            this.travelDal = travelDal;
        }

        public void Add(Travel travel)
        {
            travelDal.Add(travel);
        }

        public List<Travel> FromWhereToWhere()
        {
            throw new NotImplementedException();
        }

        public List<Travel> GetAll()
        {
            return travelDal.GetAll();
        }

        public Travel GetById(int id)
        {
            return travelDal.GetById(id);
        }

        public void Delete(Travel travel)
        {
            travelDal.Delete(travel);
        }
    }
}
