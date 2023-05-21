using SAS.Data;
using SAS.Interfaces;
using SAS.Models;
using SAS.Models.ViewModels.SASViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Controllers
{
    public class UserAreasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserAreasController> _logger;
        private readonly IUserAreas _userareasService;
        public UserAreasController(ILogger<UserAreasController> logger, ApplicationDbContext context, IUserAreas userareasService)
        {
            _logger = logger;
            _userareasService = userareasService;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllUserAreasInJson()
        {
            List<UserAreas> data = await _userareasService.GetAllUserArea();
            return Json(new { data });
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllUserAreasWithUserIDInJson(string UserID)
        {
            List<UserAreasVM> data = await _userareasService.GetAllUserAreasWithUserID(UserID);
            return Json(new { data });
        }
    }
}
