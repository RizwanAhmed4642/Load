using SAS.Common.Attributes;
using SAS.Data;
using SAS.Models;
using SAS.Models.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using SAS.Interfaces;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Text.Json;
using System.Data;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SAS.Controllers
{
    public class MapsController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserAreas _userareasService;
        private readonly IArea _areasService;
        private readonly ILogger _logger;
        public MapsController(ILogger<MapsController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, IUserAreas userareasService, IArea areasService)
        {
            _context = context;
            _userManager = userManager;
            _userareasService = userareasService;
            _areasService = areasService;
            _logger = logger;
            _areasService = areasService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> ShowArea(string areaID = "0")
        {
            AreaVM model = new AreaVM();
            model = await _areasService.GetSingleAreaWithSearch(areaID);
            return View(model);
        }

        public async Task<IActionResult> Index()
        {
            ////Getting the User Information
            var user = await _userManager.GetUserAsync(User);
            ApplicationUser app = new ApplicationUser();
            app.Id = user.Id;
            app.UserName = user.UserName;
            app.Email = user.Email;
            app.FirstName = user.FirstName;
            app.LastName = user.LastName;
            app.AvatarURL = user.AvatarURL;
            app.DateRegistered = user.DateRegistered;
            app.Position = user.Position;
            app.NickName = user.NickName;
            app.UserCountry = ((EnumCountriesVM)int.Parse((user.UserCountry))).ToString();
            app.Address = user.Address;

            var currentRole = await _userManager.GetRolesAsync(user);
            ////If the user has Administrator role then show everything means every area and Venues
            if (currentRole[0].Equals("Administrator"))
            {
                List<Area> data = await _areasService.GetAllArea();
                ViewBag.userAreasString = JsonSerializer.Serialize(new { data });

                List<GoogleMapPinsVM> pins = await _userareasService.GetAllUserAreasAndVenus();
                ViewBag.userPinsString = HttpUtility.JavaScriptStringEncode(JsonSerializer.Serialize(new { pins }));
            }
            else
            {
                List<UserAreasVM> data = await _userareasService.GetAllUserAreasWithUserID(app.Id);
                ViewBag.userAreasString = JsonSerializer.Serialize(new { data });

                List<GoogleMapPinsVM> pins = await _userareasService.GetAllUserAreasAndVenusWithUserID(app.Id);
                ViewBag.userPinsString = HttpUtility.JavaScriptStringEncode(JsonSerializer.Serialize(new { pins }));
            }

            return View(app);
        }
        private static List<SelectListItem> GetSchoolTypes()
        {
            List<SelectListItem> schoolTypes = new List<SelectListItem>();
            schoolTypes.Add(new SelectListItem { Text = "Public", Value = "Public" });
            schoolTypes.Add(new SelectListItem { Text = "Private", Value = "Private" });
            schoolTypes.Add(new SelectListItem { Text = "Catholic", Value = "Catholic" });
            return schoolTypes;
        }
        public async Task<IActionResult> MapDetails()
        {
            ////Getting the User Information
            var user = await _userManager.GetUserAsync(User);
            ApplicationUser app = new ApplicationUser();
            app.Id = user.Id;
            app.UserName = user.UserName;
            app.Email = user.Email;
            app.FirstName = user.FirstName;
            app.LastName = user.LastName;
            app.AvatarURL = user.AvatarURL;
            app.DateRegistered = user.DateRegistered;
            app.Position = user.Position;
            app.NickName = user.NickName;
            app.UserCountry = ((EnumCountriesVM)int.Parse((user.UserCountry))).ToString();
            app.Address = user.Address;

            ViewData["AreaID"] = new SelectList(_context.Area, "ID", "Nm");
            ViewData["SREStatusID"] = new SelectList(_context.CurrentStatus, "ID", "Nm");
            ViewData["Type"] = GetSchoolTypes();

            var currentRole = await _userManager.GetRolesAsync(user);
            ////If the user has Administrator role then show everything means every area and Venues
            if (currentRole[0].Equals("Administrator"))
            {
                List<Area> data = await _areasService.GetAllArea();
                ViewBag.userAreasString = JsonSerializer.Serialize(new { data });

                List<GoogleMapPinsVM> pins = await _userareasService.GetAllUserAreasAndVenus();
                ViewBag.userPinsString = HttpUtility.JavaScriptStringEncode(JsonSerializer.Serialize(new { pins }));
            }
            else
            {
                List<UserAreasVM> data = await _userareasService.GetAllUserAreasWithUserID(app.Id);
                ViewBag.userAreasString = JsonSerializer.Serialize(new { data });

                List<GoogleMapPinsVM> pins = await _userareasService.GetAllUserAreasAndVenusWithUserID(app.Id);
                ViewBag.userPinsString = HttpUtility.JavaScriptStringEncode(JsonSerializer.Serialize(new { pins }));
            }

            return View(app);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocationsInJsonAsync(string locationType, int areaID = 0)
        {
            List<GoogleMapPinsVM> resultList = new List<GoogleMapPinsVM>();
            ////Getting the User Information
            var user = await _userManager.GetUserAsync(User);
            ApplicationUser app = new ApplicationUser();
            app.Id = user.Id;
            app.UserName = user.UserName;
            app.Email = user.Email;
            app.FirstName = user.FirstName;
            app.LastName = user.LastName;
            app.AvatarURL = user.AvatarURL;
            app.DateRegistered = user.DateRegistered;
            app.Position = user.Position;
            app.NickName = user.NickName;

            var currentRole = await _userManager.GetRolesAsync(user);
            ////If the user has Administrator role then show everything means every area and Venues
            if (currentRole[0].Equals("Administrator"))
            {
                if (locationType == "All")
                {
                    resultList = await _userareasService.GetAllUserAreasAndVenus(areaID);
                }
                else if (locationType == "HighSchool")
                {
                    resultList = await _userareasService.GetAllUserAreasAndHighSchoolVenus(areaID);
                }
                else if (locationType == "PrimarySchool")
                {
                    resultList = await _userareasService.GetAllUserAreasAndPrimarySchoolVenus(areaID);
                }
                else if (locationType == "Church")
                {
                    resultList = await _userareasService.GetAllUserAreasAndChurchVenus(areaID);
                }
            }
            else
            {
                if (locationType == "All")
                {
                    resultList = await _userareasService.GetAllUserAreasAndVenusWithUserID(app.Id, areaID);
                }
                else if (locationType == "HighSchool")
                {
                    resultList = await _userareasService.GetAllUserAreasAndHighSchoolVenusWithUserID(app.Id, areaID);
                }
                else if (locationType == "PrimarySchool")
                {
                    resultList = await _userareasService.GetAllUserAreasAndPrimarySchoolVenusWithUserID(app.Id, areaID);
                }
                else if (locationType == "Church")
                {
                    resultList = await _userareasService.GetAllUserAreasAndChurchVenusWithUserID(app.Id, areaID);
                }
            }
            return Json(new { data = resultList });
        }
    }
}
