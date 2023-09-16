using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ToDo.WebApp.Models;

public class Show:Entity
{
	[NotMapped]
	public string Category { get; set; }
	[NotMapped]
	public string Status { get; set; }
    public  int UserId { get; set; }
	public int DutyId { get; set; }

    [NotMapped]
    public string? UserName { get; set; }

    [NotMapped]
    public string? DutyName { get; set; }

	[NotMapped]
	public string DutyDate { get; set; }
    
    [NotMapped]
	public string UserDate { get; set; }

	[NotMapped]
	public string Priority { get; set; }

	[NotMapped]
	public List<SelectListItem> DutyList { get; set;}

	[NotMapped]
	public List<SelectListItem> UserList { get; set;}
}
