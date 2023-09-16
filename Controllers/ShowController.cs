using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDo.WebApp.Models;
using ToDo.WebApp.Repository.Abstract;

namespace ToDo.WebApp.Controllers;

public class ShowController : Controller
{
	private readonly IShowRepository _showRepository;
	private readonly IUserRepository _userRepository;
	private readonly IDutyRepository _dutyRepository;

	public ShowController(IShowRepository showRepository, IUserRepository userRepository, IDutyRepository dutyRepository)
	{
		_showRepository = showRepository;
		_userRepository = userRepository;
        _dutyRepository = dutyRepository;
	}
	public IActionResult Index()
	{
		var lists = _showRepository.GetAll();
		return View(lists);
	}
	[HttpGet]
	public IActionResult Create()
	{
		var model = new Show();
		model.UserList = _userRepository.GetAll().Select(a => new SelectListItem{ Text = a.Name,Value = a.Id.ToString()}).ToList();
		model.DutyList =_dutyRepository.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString()}).ToList();
		return View(model);
	}
	[HttpPost]
	public IActionResult Create(Show show)
	{
		show.UserList = _userRepository.GetAll().Select(a=> new SelectListItem { Text = a.Name,Value=a.Id.ToString(),Selected = a.Id == show.UserId}).ToList();
		show.DutyList = _dutyRepository.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == show.DutyId }).ToList();
		_showRepository.Add(show);
		return RedirectToAction("Create");
	}
	[HttpGet]
	public IActionResult Delete(int id)
	{
		_showRepository.Delete(id);
		return RedirectToAction("Index");
	}
	[HttpGet]
	public IActionResult Update(int id)
	{
		var modelId = _showRepository.GetById(id);
		modelId.UserList = _userRepository.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == modelId.UserId }).ToList();
		modelId.DutyList = _dutyRepository.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(),Selected = a.Id==modelId.DutyId}).ToList();
		return View(modelId);
	}
	[HttpPost]
	public IActionResult Update(Show show)
	{
		show.UserList = _userRepository.GetAll().Select(a => new SelectListItem{ Text = a.Name, Value = a.Id.ToString(),Selected = a.Id == show.UserId}).ToList();
		show.DutyList = _dutyRepository.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(),Selected = a.Id == show.DutyId}).ToList();
		_showRepository.Update(show);
		return RedirectToAction("Index");
	}


}
