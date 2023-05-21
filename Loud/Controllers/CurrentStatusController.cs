using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NUglify.Helpers;
using SAS.Data;
using SAS.Interfaces;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Controllers
{
    public class CurrentStatusController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CurrentStatusController> _logger;
        private readonly ICurrentStatus _CurrentStatusService;
        public CurrentStatusController(ILogger<CurrentStatusController> logger, ApplicationDbContext context, ICurrentStatus CurrentStatusService)
        {
            _logger = logger;
            _CurrentStatusService = CurrentStatusService;
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
            ViewData["PASuburbID"] = new SelectList(_context.Suburb, "ID", "Nm");
            return View();
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(CurrentStatusVM model)
        {

            if (model.Nm != "")
            {

                //Saving the data in database
                ErrorVM error = await _CurrentStatusService.CreateNEditCurrentStatus(model);

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
        public async Task<IActionResult> EditCurrentStatus(string id)
        {

            if (id.IsNullOrWhiteSpace() == false)
            {

                //Saving the data in database
                CurrentStatusVM data = await _CurrentStatusService.GetSingleCurrentStatusWithSearch(id);

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
        public async Task<IActionResult> UpdateCurrentStatus(CurrentStatusVM model)
        {

            if (model.ID.ToString() != "" && model.Nm != "")
            {

                //Saving the data in database
                ErrorVM error = await _CurrentStatusService.CreateNEditCurrentStatus(model, model.ID.ToString());

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
        public async Task<IActionResult> DeleteCurrentStatus(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _CurrentStatusService.DeleteCurrentStatus(id);

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
        public async Task<IActionResult> GetAllCurrentStatussInJson()
        {
            List<CurrentStatusVM> data = await _CurrentStatusService.GetAllCurrentStatus();
            return Json(new { data });
        }
    }
}
