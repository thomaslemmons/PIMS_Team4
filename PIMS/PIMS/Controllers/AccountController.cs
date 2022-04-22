using LoginRegister.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PIMS.Data;
using System.Linq;
using System.Threading.Tasks;
namespace LoginRegister.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email

                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                { 
                    //await _userManager.AddToRoleAsync(user, "Admin");
                    return RedirectToAction("Index", "Home");
                }

            }
            ModelState.AddModelError("", "Invalid Register.");
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {        
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    //var user = await _userManager.FindByNameAsync(model.Email);
                    return RedirectToAction("Index", "Home");
                    //user role list here
                   // var roles = await _userManager.GetRolesAsync(user);
                    //get default role here
                    //string role = roles.FirstOrDefault();
                    //if (role.Equals("Admin"))
                    //{
                        //return RedirectToAction("DoctorPatientList", "Home");
                    //}
                    //else if (role.Equals("User"))
                    //{
                        //return RedirectToAction("DoctorPatientList", "Home");
                    //}
                    //else
                    //{
                        //do something here. put in your logic 
                    //}
                }
           }
            ModelState.AddModelError("", "Invalid ID or Password");
            return View(model);
        }
    }
}
