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
using System.Collections;

namespace SAS.Controllers
{
    public class SearchesController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserAreas _userareasService;
        private readonly IArea _areasService;
        private readonly ILogger _logger;
        public SearchesController(ILogger<SearchesController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, IUserAreas userareasService, IArea areasService)
        {
            _context = context;
            _userManager = userManager;
            _userareasService = userareasService;
            _areasService = areasService;
            _logger = logger;
            _areasService = areasService;
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            Dictionary<string, string> controllers = new Dictionary<string, string>();
            controllers.Add("Account", "Account");
            controllers.Add("Area", "Area");
            controllers.Add("Chaplain", "Chaplain");
            controllers.Add("ChaplainTask", "Chaplain Task");
            controllers.Add("ChaplainTaskType", "Chaplain Task Type");
            controllers.Add("Church", "Church");
            controllers.Add("CurrentStatus", "SRE Status");
            controllers.Add("HighSchool", "High School");
            controllers.Add("SchoolGrade", "School Grade");
            controllers.Add("Maps", "Maps");
            controllers.Add("Minister", "Minister");
            controllers.Add("MinisterFraternal", "Minister Fraternal");
            controllers.Add("MinisterFraternalTask", "Minister Fraternal Task");
            controllers.Add("MinisterFraternalTaskType", "Minister Fraternal Task Type");
            controllers.Add("Ministry", "Ministry");
            controllers.Add("MinistryType", "Ministry Type");
            controllers.Add("PrimarySchool", "Primary School");
            controllers.Add("SREBoard", "SRE Board");
            controllers.Add("SREBoardTask", "SRE Board Task");
            controllers.Add("SREBoardType", "SRE Board Task Type");
            controllers.Add("SRECoordinator", "SRE Coordinator");
            controllers.Add("SRECoordinatorTask", "SRE Coordinator Task");
            controllers.Add("SRECoordinatorTaskType", "SRE Coordinator Task Type");
            controllers.Add("SRERep", "SRE Rep");
            controllers.Add("State", "State");
            controllers.Add("Suburb", "Suburb");
            controllers.Add("Task", "Task");
            controllers.Add("TaskType", "Task Type");
            controllers.Add("Trip", "Trip");
            controllers.Add("UserLogs", "User Logs");

            if (!string.IsNullOrEmpty(search))
            {
                for (int i = controllers.Count - 1; i >= 0; i--)
                {
                    if (!controllers.ElementAt(i).Value.ToLower().Contains(search.ToLower()))
                    {
                        controllers.Remove(controllers.ElementAt(i).Key);
                    }
                }
            }

            return View(controllers);
        }

    }
}
