using SAS.Data;
using SAS.Interfaces;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NUglify.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Controllers
{
    public class ChaplainTaskController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ChaplainTaskController> _logger;
        private readonly IChaplainTask _chaplainTaskService;
        private readonly UserManager<ApplicationUser> _userManager;
        public ChaplainTaskController(ILogger<ChaplainTaskController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context, IChaplainTask chaplainTaskService)
        {
            _logger = logger;
            _chaplainTaskService = chaplainTaskService;
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
            ViewData["ChaplainID"] = new SelectList(_context.Chaplain, "ID", "Nm");
            ViewData["ChaplainTaskTypeID"] = new SelectList(_context.ChaplainTaskType, "ID", "Nm");
            ViewData["AssignToID"] = new SelectList(_userManager.Users, "Id", "FirstName");
            return View();
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(ChaplainTaskVM model)
        {

            if (model.ChaplainID != null && model.ChaplainTaskTypeID != null && model.StartDate != null && model.AssignToID != null)
            {

                //Saving the data in database
                ErrorVM error = await _chaplainTaskService.CreateNEditChaplainTask(model);

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
        public async Task<IActionResult> EditChaplainTask(string id)
        {

            if (id.IsNullOrWhiteSpace() == false)
            {

                //Saving the data in database
                ChaplainTaskVM data = await _chaplainTaskService.GetSingleChaplainTaskWithSearch(id);

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
        public async Task<IActionResult> UpdateChaplainTask(ChaplainTaskVM model)
        {

            if (model.ChaplainID != null && model.ChaplainTaskTypeID != null && model.StartDate != null && model.AssignToID != null)
            {

                //Saving the data in database
                ErrorVM error = await _chaplainTaskService.CreateNEditChaplainTask(model, model.ID.ToString());

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
        public async Task<IActionResult> DeleteChaplainTask(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _chaplainTaskService.DeleteChaplainTask(id);

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
        public async Task<IActionResult> GetAllChaplainTasksInJson()
        {
            List<ChaplainTaskVM> data = await _chaplainTaskService.GetAllChaplainTask();
            return Json(new { data });
        }
    }
}
