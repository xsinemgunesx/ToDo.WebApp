using ToDo.WebApp.Models;

namespace ToDo.WebApp.Repository.Abstract;

public interface IBaseRepository<TEntity> where TEntity : Entity, new()
{
	void Add(TEntity entity);
	void Update(TEntity entity);
	void Delete(int id);
	TEntity GetById(int id);
	IEnumerable<TEntity> GetAll();
}
