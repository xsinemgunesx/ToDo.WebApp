using Microsoft.AspNetCore.Mvc;
using ToDo.WebApp.Models;
using ToDo.WebApp.Repository.Abstract;
using ToDo.WebApp.Repository.Implementation;

namespace ToDo.WebApp.Controllers;

public class UserController : Controller
{
	private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public IActionResult Index()
	{
		var users = _userRepository.GetAll();
		return View(users);
	}
	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}
	[HttpPost]
	public IActionResult Create(User user)
	{
		_userRepository.Add(user);
		return RedirectToAction("Create");
	}
	[HttpGet]
	public IActionResult Delete(int id)
	{
		_userRepository.Delete(id);
		return RedirectToAction("Index");
	}
	[HttpGet]
	public IActionResult Update(int id)
	{
		var modelId = _userRepository.GetById(id);
		return View(modelId);
	}
	[HttpPost]
	public IActionResult Update(User user)
	{
		_userRepository.Update(user);
		return RedirectToAction("Index");
	}


}
