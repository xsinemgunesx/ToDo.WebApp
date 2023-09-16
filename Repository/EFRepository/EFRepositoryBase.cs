using Microsoft.EntityFrameworkCore;
using ToDo.WebApp.Models;
using ToDo.WebApp.Repository.Abstract;
using ToDo.WebApp.Repository.Implementation;

namespace ToDo.WebApp.Repository.EFRepository;

public class EFRepositoryBase<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, new()
{
	private readonly BaseDbContext _context;
	public EFRepositoryBase(BaseDbContext context)
	{
		_context = context;
	}
	public void Add(TEntity entity)
	{
		_context.Set<TEntity>().Add(entity);//ne tip olacağını bilmediğimiz için set kullanırız o tipe göre işlem yapar
		_context.SaveChanges();
	}

	public void Delete(int id)
	{
		TEntity? entity = _context.Set<TEntity>().Where(x => x.Id == id).SingleOrDefault();
		_context.Remove(entity);
		_context.SaveChanges();
	}

	public IEnumerable<TEntity> GetAll()

	{
		return _context.Set<TEntity>().ToList();
	}

    public TEntity GetById(int id) => _context.Set<TEntity>().SingleOrDefault(x => x.Id == id);

    public void Update(TEntity entity)
	{
		_context.Set<TEntity>().Update(entity);
		_context.SaveChanges();
	}
}


