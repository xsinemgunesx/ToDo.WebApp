using Microsoft.EntityFrameworkCore;
using ToDo.WebApp.Models;
using ToDo.WebApp.Repository.Abstract;
using ToDo.WebApp.Repository.EFRepository;
namespace ToDo.WebApp.Repository.Implementation;


public class ShowRepository : EFRepositoryBase<Show>, IShowRepository
{
	private readonly BaseDbContext _context;
	public ShowRepository(BaseDbContext context): base(context)
    {
        _context = context;
    }
   
    public new virtual List<Show> GetAll()
    {
        var data = (from show in _context.Shows
                    join user in _context.Users
                    on show.UserId equals user.Id
                    join duty in _context.Dutys
                    on show.DutyId equals duty.Id
                    select new Show
                    {
                        Id = show.Id,
                        UserId = user.Id,
                        DutyId = duty.Id,
                        Category = duty.Category,
                        DutyDate = duty.dutyDate,
                        UserDate = user.DateOnly,
                        Status = show.Status,
                        Priority = duty.priorityLevel,
                    }).ToList();
        return data;
    }
}