using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NUglify.Helpers;
using SAS.Common;
using SAS.Data;
using SAS.Interfaces;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAS.Controllers
{
    public class MinistryController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MinistryController> _logger;
        private readonly IMinistry _ministryService;
        public MinistryController(ILogger<MinistryController> logger, ApplicationDbContext context, IMinistry ministryService)
        {
            _logger = logger;
            _ministryService = ministryService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Create(string cmID = "")
        {

            MinistryVM data = new MinistryVM();
            if (cmID != "")
                data.ChurchID = Convert.ToInt32(cmID);
            ViewBag.btnSubmitFormText = "Create";
            GlobalHelper gh = new GlobalHelper(_context);
			var subList = gh.GetSuburbsSelectListWithPostCode();
			ViewData["ChurchID"] = new SelectList(_context.Church, "ID", "Nm");
            ViewData["MinistryTypeID"] = new SelectList(_context.MinistryType, "ID", "Nm");
            ViewData["PASuburbID"] = subList;
            ViewData["SASuburbID"] = subList;
            return View(data);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(MinistryVM model)
        {

            if (model.FirstName != "" && model.Phone1 != "" && model.email != "")
            {

                //Saving the data in database
                ErrorVM error = await _ministryService.CreateNEditMinistry(model);

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
        public async Task<IActionResult> EditMinistry(string id)
        {

            if (id.IsNullOrWhiteSpace() == false)
            {

                //Saving the data in database
                MinistryVM data = await _ministryService.GetSingleMinistryWithSearch(id);

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
        public async Task<IActionResult> UpdateMinistry(MinistryVM model)
        {

            if (model.ID.ToString() != "" && model.FirstName != "" && model.Phone1 != "" && model.email != "")
            {

                //Saving the data in database
                ErrorVM error = await _ministryService.CreateNEditMinistry(model, model.ID.ToString());

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
        public async Task<IActionResult> DeleteMinistry(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _ministryService.DeleteMinistry(id);

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
        public async Task<IActionResult> GetAllMinistrysInJson()
        {
            List<MinistryVM> data = await _ministryService.GetAllMinistry();
            return Json(new { data });
        }
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllMinistrysWithChurch(string cID)
        {
            List<MinistryVM> data = await _ministryService.GetAllMinistrysWithChurch(cID);
            return Json(new { data });
        }
    }
}
