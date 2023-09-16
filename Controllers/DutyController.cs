using Microsoft.AspNetCore.Mvc;
using ToDo.WebApp.Models;
using ToDo.WebApp.Repository.Abstract;

namespace ToDo.WebApp.Controllers;

public class DutyController : Controller
{
	private readonly IDutyRepository _dutyRepository;
	public DutyController(IDutyRepository dutyRepository)
	{
        _dutyRepository = dutyRepository;
	}
	public IActionResult Index()
	{
		var dutys = _dutyRepository.GetAll();
		return View(dutys);
	}
	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}
	[HttpPost]
	public IActionResult Create(Duty duty)
	{
        _dutyRepository.Add(duty);
		return RedirectToAction("Create");
	}
	[HttpGet]
	public IActionResult Delete(int id)
	{
        _dutyRepository.Delete(id);
		return RedirectToAction("Index");
	}
	[HttpGet]
	public IActionResult Update(int id)
	{
		var modelId = _dutyRepository.GetById(id);
		return View(modelId);
	}
	[HttpPost]
	public IActionResult Update(Duty duty)
	{
        _dutyRepository.Update(duty);
		return RedirectToAction("Index");
	}


}
