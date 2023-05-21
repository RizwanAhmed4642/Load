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
    public class SRECoordinatorTaskController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SRECoordinatorTaskController> _logger;
        private readonly ISRECoordinatorTask _sreCoordinatorTaskService;
        private readonly UserManager<ApplicationUser> _userManager;
        public SRECoordinatorTaskController(ILogger<SRECoordinatorTaskController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context, ISRECoordinatorTask sreCoordinatorTaskService)
        {
            _logger = logger;
            _sreCoordinatorTaskService = sreCoordinatorTaskService;
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
            ViewData["SRECoordinatorID"] = new SelectList(_context.SRECoordinator, "ID", "Nm");
            ViewData["SRECoordinatorTaskTypeID"] = new SelectList(_context.SRECoordinatorTaskType, "ID", "Nm");
            ViewData["AssignToID"] = new SelectList(_userManager.Users, "Id", "FirstName");
            return View();
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(SRECoordinatorTaskVM model)
        {

            if (model.SRECoordinatorID != null && model.SRECoordinatorTaskTypeID != null && model.StartDate != null && model.AssignToID != null)
            {

                //Saving the data in database
                ErrorVM error = await _sreCoordinatorTaskService.CreateNEditSRECoordinatorTask(model);

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
        public async Task<IActionResult> EditSRECoordinatorTask(string id)
        {

            if (id.IsNullOrWhiteSpace() == false)
            {

                //Saving the data in database
                SRECoordinatorTaskVM data = await _sreCoordinatorTaskService.GetSingleSRECoordinatorTaskWithSearch(id);

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
        public async Task<IActionResult> UpdateSRECoordinatorTask(SRECoordinatorTaskVM model)
        {

            if (model.SRECoordinatorID != null && model.SRECoordinatorTaskTypeID != null && model.StartDate != null && model.AssignToID != null)
            {

                //Saving the data in database
                ErrorVM error = await _sreCoordinatorTaskService.CreateNEditSRECoordinatorTask(model, model.ID.ToString());

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
        public async Task<IActionResult> DeleteSRECoordinatorTask(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _sreCoordinatorTaskService.DeleteSRECoordinatorTask(id);

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
        public async Task<IActionResult> GetAllSRECoordinatorTasksInJson()
        {
            List<SRECoordinatorTaskVM> data = await _sreCoordinatorTaskService.GetAllSRECoordinatorTask();
            return Json(new { data });
        }
    }
}
