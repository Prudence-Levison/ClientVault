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
     return View(new User());
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

public IActionResult Edit(int Id){
    var user =_userRepository.GetById(Id);
    if(user == null)
    return NotFound();

    return View( "Create", user);
}

[HttpPost]
public IActionResult Edit(User user){
     _userRepository.Update(user);
     TempData["SuccessMessage"] = "User updated successfully!";
     return RedirectToAction("Index");
}

public IActionResult Delete(int Id){
    _userRepository.Delete(Id);
    TempData["SuccessMessage"] = "User deleted successfully!";
     return RedirectToAction("Index");
}
  public IActionResult Index()
    {
        var users = _userRepository.GetAll();
        return View(users);
    }
    
}