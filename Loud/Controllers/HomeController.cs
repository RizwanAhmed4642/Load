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
using System.Web;

namespace SAS.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserAreas _userareasService;
        private readonly ILogger _logger;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, IUserAreas userareasService)
        {
            _context = context;
            _userManager = userManager;
            _userareasService = userareasService;
            _logger = logger;
        }

        [HelpDefinition]
        public async Task<IActionResult> Index()
        {
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


            List<UserAreasVM> data = await _userareasService.GetAllUserAreasWithUserID(app.Id);
            ViewBag.userAreasString = JsonSerializer.Serialize(new { data });

            List<GoogleMapPinsVM> pins = await _userareasService.GetAllUserAreasAndVenusWithUserID(app.Id);
            ViewBag.userPinsString = HttpUtility.JavaScriptStringEncode(JsonSerializer.Serialize(new { pins }));
            //pins.RemoveRange(5, pins.Count - 5);


            ViewBag.totalUsers = _userManager.Users.Count();
            ViewBag.totalHighSchool = _context.HighSchool.Count();
            ViewBag.totalPrimarySchool = _context.PrimarySchool.Count();
            ViewBag.totalChurch = _context.Church.Count();
            ViewBag.totalChaplain = _context.Chaplain.Count();
            ViewBag.totalArea = _context.Area.Count();
            ViewBag.totalSRERep = _context.SRERep.Count();
            ViewBag.totalSREBoard = _context.SREBoard.Count();
            ViewBag.totalMinister = _context.Minister.Count();
            ViewBag.totalMinisterFraternal = _context.MinisterFraternal.Count();
            ViewBag.totalMinistry = _context.Ministry.Count();
            ViewBag.totalTrip = _context.Trip.Count();
            ViewBag.totalTask = _context.Task.Count();
            ViewBag.totalSuburb = _context.Suburb.Count();
            ViewBag.totalState = _context.State.Count();
            ViewBag.totalSchoolGrade = _context.SchoolGrade.Count();
            AddPageHeader("Dashboard", "");
            return View(app);
        }

        [HttpPost]
        public IActionResult Index(object model)
        {
            AddPageAlerts(PageAlertType.Info, "you may view the summary <a href='#'>here</a>");
            return View("Index");
        }

        [HelpDefinition]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            AddBreadcrumb("About", "/Account/About");

            return View();
        }

        [HelpDefinition("helpdefault")]
        public IActionResult Contact()
        {
            AddBreadcrumb("Register", "/Account/Register");
            AddBreadcrumb("Contact", "/Account/Contact");
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
