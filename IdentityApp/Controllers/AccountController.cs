using IdentityApp.Models;
using IdentityApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers
{
    public class AccountController : Controller{

        private RoleManager<AppRole> _roleManager;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        public AccountController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager,SignInManager<AppUser> signInManager){
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model){

            if(ModelState.IsValid){
                var user = await _userManager.FindByEmailAsync(model.Email);
                if(user!=null){
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password,model.RememberMe,true);
                    if(result.Succeeded){
                        await _userManager.ResetAccessFailedCountAsync(user);
                        await _userManager.SetLockoutEndDateAsync(user,null);

                        return RedirectToAction("Index","Home");
                    }
                    else if(result.IsLockedOut){
                        var lockuotDate = await _userManager.GetLockoutEndDateAsync(user);
                        var timeLeft = lockuotDate.Value - DateTime.Now;
                        ModelState.AddModelError("",$"Hesabınız kitlendi, Lütfen {timeLeft.Minutes} dakika sonra tekrar deneyiniz!");
                    }
                    else{
                    ModelState.AddModelError("", "parolanız hatalı");
                }
                }
                else{
                    ModelState.AddModelError("", "Bu email adresiyle ilişkili bir hesap bulunamadı");
                }
            }

            return View(model);
        }
    }
}