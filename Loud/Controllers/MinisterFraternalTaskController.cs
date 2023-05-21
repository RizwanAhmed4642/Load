using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NUglify.Helpers;
using SAS.Data;
using SAS.Interfaces;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Controllers
{
    public class MinisterFraternalTaskController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MinisterFraternalTaskController> _logger;
        private readonly IMinisterFraternalTask _ministerFraternalTaskService;
        private readonly UserManager<ApplicationUser> _userManager;
        public MinisterFraternalTaskController(ILogger<MinisterFraternalTaskController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMinisterFraternalTask ministerFraternalTaskService)
        {
            _logger = logger;
            _ministerFraternalTaskService = ministerFraternalTaskService;
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
            ViewData["MinisterFraternalID"] = new SelectList(_context.MinisterFraternal, "ID", "Nm");
            ViewData["MinisterFraternalTaskTypeID"] = new SelectList(_context.MinisterFraternalTaskType, "ID", "Nm");
            ViewData["AssignToID"] = new SelectList(_userManager.Users, "Id", "FirstName");
            return View();
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(MinisterFraternalTaskVM model)
        {

            if (model.MinisterFraternalID != null && model.MinisterFraternalTaskTypeID != null && model.StartDate != null && model.AssignToID != null)
            {

                //Saving the data in database
                ErrorVM error = await _ministerFraternalTaskService.CreateNEditMinisterFraternalTask(model);

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
        public async Task<IActionResult> EditMinisterFraternalTask(string id)
        {

            if (id.IsNullOrWhiteSpace() == false)
            {

                //Saving the data in database
                MinisterFraternalTaskVM data = await _ministerFraternalTaskService.GetSingleMinisterFraternalTaskWithSearch(id);

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
        public async Task<IActionResult> UpdateMinisterFraternalTask(MinisterFraternalTaskVM model)
        {

            if (model.MinisterFraternalID != null && model.MinisterFraternalTaskTypeID != null && model.StartDate != null && model.AssignToID != null)
            {

                //Saving the data in database
                ErrorVM error = await _ministerFraternalTaskService.CreateNEditMinisterFraternalTask(model, model.ID.ToString());

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
        public async Task<IActionResult> DeleteMinisterFraternalTask(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _ministerFraternalTaskService.DeleteMinisterFraternalTask(id);

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
        public async Task<IActionResult> GetAllMinisterFraternalTasksInJson()
        {
            List<MinisterFraternalTaskVM> data = await _ministerFraternalTaskService.GetAllMinisterFraternalTask();
            return Json(new { data });
        }
    }
}
