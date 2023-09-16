using ToDo.WebApp.Models;
using ToDo.WebApp.Repository.Abstract;
using ToDo.WebApp.Repository.EFRepository;

namespace ToDo.WebApp.Repository.Implementation;

public class UserRepository : EFRepositoryBase<User>, IUserRepository
{
	public UserRepository(BaseDbContext context) : base(context)
	{

	}
}
