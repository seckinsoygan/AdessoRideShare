using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ITravelDal
    {
        List<Travel> GetAll();
        Travel GetById(int id);
        void Add(Travel travel);
        void Delete(Travel travel);
        void Update(Travel travel);
    }
}
