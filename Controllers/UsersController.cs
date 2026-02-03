using Microsoft.AspNetCore.Mvc;
using adonetdatabase.Data;

using adonetdatabase.Models;


namespace Users.Controllers;

public class UsersController : Controller

{
    
    private readonly UserRepository _userRepository;

    public UsersController()
{
    _userRepository = new UserRepository();
}
    public IActionResult Create()
{
    return View();
}
[HttpPost]
public IActionResult Create( User user)
{
    if(!ModelState.IsValid){

        return View (user);


    }
    _userRepository.Create(user);

    TempData["SuccessMessage"] = "User added successfully!";

    return RedirectToAction("Index");
}

public IActionResult Index()
    {
        var users = _userRepository.GetAll();
        return View(users);
    }
    
}