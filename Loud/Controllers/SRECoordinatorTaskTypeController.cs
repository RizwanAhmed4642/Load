using SAS.Data;
using SAS.Interfaces;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUglify.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Controllers
{

    public class SRECoordinatorTaskTypeController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SRECoordinatorTaskTypeController> _logger;
        private readonly ISRECoordinatorTaskType _sreCoordinatorTaskTypeService;
        public SRECoordinatorTaskTypeController(ILogger<SRECoordinatorTaskTypeController> logger, ApplicationDbContext context, ISRECoordinatorTaskType sreCoordinatorTaskTypeService)
        {
            _logger = logger;
            _sreCoordinatorTaskTypeService = sreCoordinatorTaskTypeService;
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
            return View();
        }


        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(SRECoordinatorTaskTypeVM model)
        {

            if (model.Nm != "")
            {

                //Saving the data in database
                ErrorVM error = await _sreCoordinatorTaskTypeService.CreateNEditSRECoordinatorTaskType(model);

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
        public async Task<IActionResult> EditSRECoordinatorTaskType(string id)
        {

            if (id.IsNullOrWhiteSpace() == false)
            {

                //Saving the data in database
                SRECoordinatorTaskTypeVM data = await _sreCoordinatorTaskTypeService.GetSingleSRECoordinatorTaskTypeWithSearch(id);

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
        public async Task<IActionResult> UpdateSRECoordinatorTaskType(SRECoordinatorTaskTypeVM model)
        {

            if (model.ID.ToString() != "" && model.Nm != "")
            {

                //Saving the data in database
                ErrorVM error = await _sreCoordinatorTaskTypeService.CreateNEditSRECoordinatorTaskType(model, model.ID.ToString());

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
        public async Task<IActionResult> DeleteSRECoordinatorTaskType(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _sreCoordinatorTaskTypeService.DeleteSRECoordinatorTaskType(id);

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
        public async Task<IActionResult> GetAllSRECoordinatorTaskTypesInJson()
        {
            List<SRECoordinatorTaskType> data = await _sreCoordinatorTaskTypeService.GetAllSRECoordinatorTaskType();
            return Json(new { data });
        }
    }
}
