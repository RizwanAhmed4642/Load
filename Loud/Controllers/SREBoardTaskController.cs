using SAS.Data;
using SAS.Interfaces;
using SAS.Models;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NUglify.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Controllers
{
    public class SREBoardTaskController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SREBoardTaskController> _logger;
        private readonly ISREBoardTask _sreBoardTaskService;
        private readonly UserManager<ApplicationUser> _userManager;
        public SREBoardTaskController(ILogger<SREBoardTaskController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context, ISREBoardTask sreBoardTaskService)
        {
            _logger = logger;
            _sreBoardTaskService = sreBoardTaskService;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Create()
        {
            ViewData["SREBoardID"] = new SelectList(_context.SREBoard, "ID", "Nm");
            ViewData["SREBoardTaskTypeID"] = new SelectList(_context.SREBoardTaskType, "ID", "Nm");
            ViewData["AssignToID"] = new SelectList(_userManager.Users, "Id", "FirstName");
            return View();
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(SREBoardTaskVM model)
        {

            if (model.SREBoardID != null && model.SREBoardTaskTypeID != null && model.StartDate != null && model.AssignToID != null)
            {

                //Saving the data in database
                ErrorVM error = await _sreBoardTaskService.CreateNEditSREBoardTask(model);

                // If the header is set to "XMLHttpRequest", it indicates that the request was made using AJAX.
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    if (error.Status)
                        return Json(new { success = true, message = error.Message, flag = "success" });
                    else
                        return Json(new { success = false, message = error.Message, flag = "error" });
                }
                // Otherwise return the html response
                else
                    return View();
            }
            else if (ModelState.IsValid)
            {
                return View();
            }
            else
                return View();
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> EditSREBoardTask(string id)
        {

            if (id.IsNullOrWhiteSpace() == false)
            {

                //Saving the data in database
                SREBoardTaskVM data = await _sreBoardTaskService.GetSingleSREBoardTaskWithSearch(id);

                // If the header is set to "XMLHttpRequest", it indicates that the request was made using AJAX.
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    if (data != null)
                        return Json(new { success = true, message = "Getting record is successful", flag = "success", data = data });
                    else
                        return Json(new { success = false, message = "Error: Getting record is not successful", flag = "error" });
                }
                // Otherwise return the html response
                else
                    return View();
            }
            else if (ModelState.IsValid)
            {
                return View();
            }
            else
                return View();
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> UpdateSREBoardTask(SREBoardTaskVM model)
        {

            if (model.SREBoardID != null && model.SREBoardTaskTypeID != null && model.StartDate != null && model.AssignToID != null)
            {

                //Saving the data in database
                ErrorVM error = await _sreBoardTaskService.CreateNEditSREBoardTask(model, model.ID.ToString());

                // If the header is set to "XMLHttpRequest", it indicates that the request was made using AJAX.
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    if (error.Status)
                        return Json(new { success = true, message = error.Message, flag = "success" });
                    else
                        return Json(new { success = false, message = error.Message, flag = "error" });
                }
                // Otherwise return the html response
                else
                    return View();
            }
            else if (ModelState.IsValid)
            {
                return View();
            }
            else
                return View();
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> DeleteSREBoardTask(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _sreBoardTaskService.DeleteSREBoardTask(id);

                // If the header is set to "XMLHttpRequest", it indicates that the request was made using AJAX.
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    if (error.Status)
                        return Json(new { success = true, message = error.Message, flag = "success" });
                    else
                        return Json(new { success = false, message = error.Message, flag = "error" });
                }
                // Otherwise return the html response
                else
                    return View();
            }
            else if (ModelState.IsValid)
            {
                return View();
            }
            else
                return View();
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllSREBoardTasksInJson()
        {
            List<SREBoardTaskVM> data = await _sreBoardTaskService.GetAllSREBoardTask();
            return Json(new { data });
        }
    }
}
