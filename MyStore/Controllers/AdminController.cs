using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore.Areas.Identity.Data;
using MyStore.Models;
using System.Runtime.Intrinsics.Arm;

namespace MyStore.Controllers
{
    public class AdminController : Controller
    {
        //_useridentity = new UserManager
         private readonly UserManager<MyStoreUser> _userManager;

        public AdminController(UserManager<MyStoreUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            List<AdminViewModel> viewmodelist = new List<AdminViewModel>();
            foreach (var user in users) {

                var admmodel = new AdminViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                  //  Password = user.PasswordHash
                };
                viewmodelist.Add(admmodel); 
            }
           

            return View(viewmodelist);
        }

        public IActionResult Create()
        {
            //same code as done below
            //var rolesViewModel = new AdminViewModel();
            //rolesViewModel.Roles = new List<string> { "Manager", "Admin", "Member" };


            var rolesViewModel = new Models.AdminViewModel
            {
                Roles = new List<string> { "Manager", "Admin", "Member" }
            };

            return View(rolesViewModel);

           // return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveRole(AdminViewModel user) {

            if (ModelState.IsValid)
            {
                if (_userManager.FindByEmailAsync(user.Email) !=null)
                {
                   // var selectedrole = user.SelectedRole;
                    var selectedrole = new List<string> {user.SelectedRole };
                    var newuser = new MyStoreUser();
                    newuser.Email = user.Email;
                    newuser.UserName = user.Email;
                    newuser.FirstName = user.FirstName;
                    newuser.LastName = user.LastName;
                    


                    //creating new user 
                 var us =  await _userManager.CreateAsync(newuser, user.Password);
                     
                  
                    
                    //assign role to newely created user
                    await _userManager.AddToRolesAsync(newuser, selectedrole);

                    return  RedirectToAction("Index");
                }


                
            }
            return RedirectToAction("Index");
        }
    }
}
