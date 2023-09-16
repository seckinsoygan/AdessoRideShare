using Entities.Concrete;

namespace Business.Abstract
{
	public interface ITravelService
	{
		List<Travel> GetAll();
		List<Travel> FromWhereToWhere();
		Travel GetById(int id);
		void Add(Travel travel);
		void Delete(Travel travel);
		void Update(Travel travel);
	}
}
