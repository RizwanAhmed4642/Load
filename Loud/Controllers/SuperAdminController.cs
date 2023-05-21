using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SAS.Models;
using SAS.Models.ViewModels;
using System.Security.Claims;
using SAS.Common;
using SAS.Models.ViewModels.SuperAdminViewModels;
using NUglify.Helpers;
using Microsoft.EntityFrameworkCore;
using SAS.Data;
using SAS.Interfaces;
using SAS.Models.ViewModels.SASViewModels;
using System.Diagnostics.Metrics;
using System.Net;

namespace SAS.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SuperAdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserAreas _userareasService;
        private readonly IArea _areaService;
        private UserManager<ApplicationUser> userManager;
        private IUserValidator<ApplicationUser> userValidator;
        private IPasswordValidator<ApplicationUser> passwordValidator;
        private IPasswordHasher<ApplicationUser> passwordHasher;

        private ApplicationUser testUser = new ApplicationUser
        {
            UserName = "TestTestForPassword",
            Email = "testForPassword@test.test"
        };

        public SuperAdminController(ApplicationDbContext context, IUserAreas userareasService, IArea areaService, UserManager<ApplicationUser> userMgr,
            IUserValidator<ApplicationUser> userValid, IPasswordValidator<ApplicationUser> passValid,
            IPasswordHasher<ApplicationUser> passHasher)
        {
            _context = context;
            _userareasService = userareasService;
            _areaService = areaService;
            userManager = userMgr;
            userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passHasher;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            return View(userManager.Users);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVm model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    //extended properties
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    AvatarURL = "/images/user.png",
                    DateRegistered = DateTime.UtcNow.ToString(),
                    Position = model.UserRole,
                    NickName = model.FirstName + " " + model.LastName,
                    UserCountry = model.UserCountry,
                    Address = model.Address,
                };

                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.GivenName, user.FirstName));
                    await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.Surname, user.LastName));
                    await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.AvatarURL, user.AvatarURL));
                    //Creating the user Role
                    await userManager.AddToRoleAsync(user, model.UserRole);

                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.TryAddModelError("", error.Description);
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrors(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }

            return View("Index", userManager.Users);
        }
        public async Task<IActionResult> EditUserAreas(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                var currentRoles = await userManager.GetRolesAsync(user);
                ViewBag.CurrentRole = currentRoles[0].ToString();
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserAreas(string id, List<string> addSelectedAreas, List<string> removeSelectedAreas, bool addAllAreasOneClick, bool removeAllAreasOneClick)
        {
            if (id.IsNullOrWhiteSpace() != true)
            {
                if (removeAllAreasOneClick == true)
                {
                    await _userareasService.DeleteUserAreaWithUserID(id);
                }
                else if (addAllAreasOneClick == true)
                {
                    List<Area> areaList = await _areaService.GetAllArea();
                    foreach (var item in areaList)
                    {
                        //Check if it is not exist already
                        if (_context.UserAreas.Any(a => a.ID == item.ID && a.UserID == id))
                        {
                            continue;
                        }
                        //then add the area against the user
                        else
                        {
                            UserAreasVM model = new UserAreasVM();
                            model.UserID = id;
                            model.AreaID = Convert.ToInt32(item.ID);
                            await _userareasService.CreateNEditUserArea(model, "");
                        }
                    }
                }
                else
                {
                    //Removing the areas for the user
                    for (int i = 0; i < removeSelectedAreas.Count; i++)
                    {
                        await _userareasService.DeleteUserArea(removeSelectedAreas[i]);
                    }

                    //Adding the areas for the user
                    for (int i = 0; i < addSelectedAreas.Count; i++)
                    {
                        //Check if it is not exist already
                        if (_context.UserAreas.Any(a => a.ID == int.Parse(addSelectedAreas[i]) && a.UserID == id))
                        {
                            continue;
                        }
                        //then add the area against the user
                        else
                        {
                            UserAreasVM model = new UserAreasVM();
                            model.UserID = id;
                            model.AreaID = Convert.ToInt32(addSelectedAreas[i]);
                            await _userareasService.CreateNEditUserArea(model, "");
                        }
                    }
                }

                ApplicationUser user = await userManager.FindByIdAsync(id);
                var currentRoles = await userManager.GetRolesAsync(user);
                ViewBag.CurrentRole = currentRoles[0].ToString();
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Edit(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                var currentRoles = await userManager.GetRolesAsync(user);
                ViewBag.CurrentRole = currentRoles[0].ToString();
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // the names of its parameters must be the same as the property of the User class if we use asp-for in the view
        // otherwise form values won't be passed properly
        public async Task<IActionResult> Edit(string id, string FirstName, string LastName, string userName, string email, string UserRole, string UserCountry, string Address)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                // Validate UserName and Email 
                // UserName won't be changed in the database until UpdateAsync is executed successfully
                user.FirstName = FirstName;
                user.LastName = LastName;
                user.UserName = userName;
                user.Email = email;
                user.UserCountry = UserCountry;
                user.Address = Address;
                IdentityResult validUseResult = await userValidator.ValidateAsync(userManager, user);
                if (!validUseResult.Succeeded)
                {
                    AddErrors(validUseResult);
                }

                // Update user info
                if (validUseResult.Succeeded)
                {
                    // UpdateAsync validates user info such as UserName and Email except password since it's been hashed 
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        //First remove the old user roles
                        var currentRoles = await userManager.GetRolesAsync(user);
                        await userManager.RemoveFromRolesAsync(user, currentRoles);
                        //Update the user role
                        await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.GivenName, user.FirstName));
                        await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.Surname, user.LastName));
                        await userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.AvatarURL, user.AvatarURL));
                        await userManager.AddToRoleAsync(user, UserRole);
                        currentRoles = await userManager.GetRolesAsync(user);

                        ViewBag.CurrentRole = currentRoles[0].ToString();
                        return RedirectToAction("Index", "SuperAdmin");
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            ;

            return View(user);
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string id, string password)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                // Validate password
                // Step 1: using built in validations
                IdentityResult passwordResult = await userManager.CreateAsync(testUser, password);
                if (passwordResult.Succeeded)
                {
                    await userManager.DeleteAsync(testUser);
                }
                else
                {
                    AddErrors(passwordResult);
                }
                /* Step 2: Because of DI, IPasswordValidator<User> is injected into the custom password validator. 
                   So the built in password validation stop working here */
                IdentityResult validPasswordResult = await passwordValidator.ValidateAsync(userManager, user, password);
                if (validPasswordResult.Succeeded)
                {
                    user.PasswordHash = passwordHasher.HashPassword(user, password);
                }
                else
                {
                    AddErrors(validPasswordResult);
                }

                // Update user info
                if (passwordResult.Succeeded && validPasswordResult.Succeeded)
                {
                    // UpdateAsync validates user info such as UserName and Email except password since it's been hashed 
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "SuperAdmin");
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }

            return View(user);
        }
    }
}
