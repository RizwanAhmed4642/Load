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
using System.Linq;
using System.Threading.Tasks;

namespace SAS.Controllers
{
    public class ChurchController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ChurchController> _logger;
        private readonly IChurch _churchService;
        public ChurchController(ILogger<ChurchController> logger, ApplicationDbContext context, IChurch churchService)
        {
            _logger = logger;
            _churchService = churchService;
            _context = context;
        }

        public IActionResult Index(string hsID = "")
        {
            ChurchVM data = new ChurchVM();
            GlobalHelper gh = new GlobalHelper(_context);
            var subList = gh.GetSuburbsSelectListWithPostCode();
            if (hsID != "")
                data.HighSchoolID = Convert.ToInt32(hsID);
            ViewBag.btnSubmitFormText = "Create";
            ViewData["AreaID"] = new SelectList(_context.Area, "ID", "Nm");
            ViewData["HighSchoolID"] = new SelectList(_context.HighSchool, "ID", "Nm");
            ViewData["MinisterFraternalID"] = new SelectList(_context.MinisterFraternal, "ID", "Nm");
            ViewData["SRECoordinatorID"] = new SelectList(_context.SRECoordinator, "ID", "Nm");
            ViewData["ChurchID"] = new SelectList(_context.Church, "ID", "Nm");
            ViewData["SREBoardID"] = new SelectList(_context.SREBoard, "ID", "Nm");
            ViewData["PASuburbID"] = subList;
            ViewData["SASuburbID"] = subList;

            return View(data);
        }


		[HttpGet]
        //[Authorize]
        public IActionResult Create(string hsID = "")
        {
            ChurchVM data = new ChurchVM();
            GlobalHelper gh = new GlobalHelper(_context);
            var subList = gh.GetSuburbsSelectListWithPostCode();
            if (hsID != "")
                data.HighSchoolID = Convert.ToInt32(hsID);
            ViewBag.btnSubmitFormText = "Create";
            ViewData["AreaID"] = new SelectList(_context.Area, "ID", "Nm");
            ViewData["HighSchoolID"] = new SelectList(_context.HighSchool, "ID", "Nm");
            ViewData["MinisterFraternalID"] = new SelectList(_context.MinisterFraternal, "ID", "Nm");
            ViewData["SRECoordinatorID"] = new SelectList(_context.SRECoordinator, "ID", "Nm");
            ViewData["ChurchID"] = new SelectList(_context.Church, "ID", "Nm");
            ViewData["SREBoardID"] = new SelectList(_context.SREBoard, "ID", "Nm");
            ViewData["PASuburbID"] = subList;
            ViewData["SASuburbID"] = subList;

            return View(data);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(ChurchVM model)
        {
            ChurchVM data = new ChurchVM();
            ViewBag.btnSubmitFormText = "Create";
            if (model.Nm != "" && model.StreetAddress != "" && model.Phone1 != "" && model.email != "")
            {

                //Saving the data in database
                ErrorVM error = await _churchService.CreateNEditChurch(model);

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
                    return View(data);
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
        public async Task<IActionResult> EditChurch(string id)
        {
            ViewBag.btnSubmitFormText = "Update";
            if (id.IsNullOrWhiteSpace() == false)
            {

                GlobalHelper gh = new GlobalHelper(_context);
                var subList = gh.GetSuburbsSelectListWithPostCode();
                ViewData["AreaID"] = new SelectList(_context.Area, "ID", "Nm");
                ViewData["HighSchoolID"] = new SelectList(_context.HighSchool, "ID", "Nm");
                ViewData["MinisterFraternalID"] = new SelectList(_context.MinisterFraternal, "ID", "Nm");
                ViewData["SRECoordinatorID"] = new SelectList(_context.SRECoordinator, "ID", "Nm");
                ViewData["ChurchID"] = new SelectList(_context.Church, "ID", "Nm");
                ViewData["SREBoardID"] = new SelectList(_context.SREBoard, "ID", "Nm");
                ViewData["PASuburbID"] = subList;
                ViewData["SASuburbID"] = subList;
                //Saving the data in database
                ChurchVM data = await _churchService.GetSingleChurchWithSearch(id);

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
                    return View("~/Views/Church/Create.cshtml", data);
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
        public async Task<IActionResult> UpdateChurch(ChurchVM model)
        {
            ViewBag.btnSubmitFormText = "Update";
            if (model.Nm != "" && model.StreetAddress != "" && model.Phone1 != "" && model.email != "")
            {

                //Saving the data in database
                ErrorVM error = await _churchService.CreateNEditChurch(model, model.ID.ToString());

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
        public async Task<IActionResult> DeleteChurch(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _churchService.DeleteChurch(id);

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
        public async Task<IActionResult> GetAllChurchsInJson()
        {
            List<ChurchVM> data = await _churchService.GetAllChurch();
            return Json(new { data });
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllChurchsWithHighSchool(string hsID)
        {
            List<ChurchVM> data = await _churchService.GetAllChurchsWithHighSchool(hsID);
            return Json(new { data });
        }
    }
}
