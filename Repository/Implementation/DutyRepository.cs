using ToDo.WebApp.Models;
using ToDo.WebApp.Repository.Abstract;
using ToDo.WebApp.Repository.EFRepository;

namespace ToDo.WebApp.Repository.Implementation;

public class DutyRepository : EFRepositoryBase<Duty>, IDutyRepository
{
	public DutyRepository(BaseDbContext context) : base(context)
	{

	}
}
