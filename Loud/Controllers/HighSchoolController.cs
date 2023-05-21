using SAS.Data;
using SAS.Interfaces;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using NUglify.Helpers;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;
using System;
using SAS.Common;

namespace SAS.Controllers
{
    public class HighSchoolController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HighSchoolController> _logger;
        private readonly IHighSchool _highSchoolService;
        public HighSchoolController(ILogger<HighSchoolController> logger, ApplicationDbContext context, IHighSchool highSchoolService)
        {
            _logger = logger;
            _highSchoolService = highSchoolService;
            _context = context;
        }

        public IActionResult Index(string type = "Public")
        {
            HighSchoolVM data = new HighSchoolVM();
            GlobalHelper gh = new GlobalHelper(_context);
            var subList = gh.GetSuburbsSelectListWithPostCode();
            if (type != "")
                data.type = type;
            ViewBag.btnSubmitFormText = "Create";
            ViewData["HighSchoolID"] = new SelectList(_context.HighSchool, "ID", "Nm");
            ViewData["OverideID"] = new SelectList(_context.Overide, "ID", "Nm");
            ViewData["AreaID"] = new SelectList(_context.Area, "ID", "Nm");
            ViewData["SREBoardID"] = new SelectList(_context.SREBoard, "ID", "Nm");
            ViewData["ChaplainID"] = new SelectList(_context.Chaplain, "ID", "Nm");
            ViewData["PASuburbID"] = subList;
            ViewData["SASuburbID"] = subList;
            ViewData["SREStatusID"] = new SelectList(_context.CurrentStatus, "ID", "Nm");
            ViewData["Type"] = gh.GetSchoolTypesSelectList();
            //ViewBag.type = type;
            return View(data);
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Create(string type = "")
        {
            HighSchoolVM data = new HighSchoolVM();
            GlobalHelper gh = new GlobalHelper(_context);
           var subList = gh.GetSuburbsSelectListWithPostCode();
            if (type != "")
                data.type = type;
            ViewBag.btnSubmitFormText = "Create";
            ViewData["HighSchoolID"] = new SelectList(_context.HighSchool, "ID", "Nm");
            ViewData["OverideID"] = new SelectList(_context.Overide, "ID", "Nm");
            ViewData["AreaID"] = new SelectList(_context.Area, "ID", "Nm");
            ViewData["SREBoardID"] = new SelectList(_context.SREBoard, "ID", "Nm");
            ViewData["ChaplainID"] = new SelectList(_context.Chaplain, "ID", "Nm");
            ViewData["PASuburbID"] = subList;
            ViewData["SASuburbID"] = subList;
            ViewData["SREStatusID"] = new SelectList(_context.CurrentStatus, "ID", "Nm");
            ViewData["Type"] = gh.GetSchoolTypesSelectList();
            return View(data);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(HighSchoolVM model)
        {
            HighSchoolVM data = new HighSchoolVM();
            ViewBag.btnSubmitFormText = "Create";
            if (model.Nm != "" && model.StreetAddress != "" && model.Phone1 != "" && model.email != "")
            {

                //Saving the data in database
                ErrorVM error = await _highSchoolService.CreateNEditHighSchool(model);

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
        public async Task<IActionResult> EditHighSchool(string id)
        {
            ViewBag.btnSubmitFormText = "Update";
            if (id.IsNullOrWhiteSpace() == false)
            {

                GlobalHelper gh = new GlobalHelper(_context);
                var subList = gh.GetSuburbsSelectListWithPostCode();
                ViewData["HighSchoolID"] = new SelectList(_context.HighSchool, "ID", "Nm");
                ViewData["OverideID"] = new SelectList(_context.Overide, "ID", "Nm");
                ViewData["AreaID"] = new SelectList(_context.Area, "ID", "Nm");
                ViewData["SREBoardID"] = new SelectList(_context.SREBoard, "ID", "Nm");
                ViewData["ChaplainID"] = new SelectList(_context.Chaplain, "ID", "Nm");
                ViewData["PASuburbID"] = subList;
                ViewData["SASuburbID"] = subList;
                ViewData["Type"] = gh.GetSchoolTypesSelectList();
                ViewData["SREStatusID"] = new SelectList(_context.CurrentStatus, "ID", "Nm");
                //Saving the data in database
                HighSchoolVM data = await _highSchoolService.GetSingleHighSchoolWithSearch(id);

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
                    return View("~/Views/HighSchool/Create.cshtml", data);
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
        public async Task<IActionResult> UpdateHighSchool(HighSchoolVM model)
        {
            ViewBag.btnSubmitFormText = "Update";
            if (model.Nm != "" && model.StreetAddress != "" && model.Phone1 != "" && model.email != "")
            {

                //Saving the data in database
                ErrorVM error = await _highSchoolService.CreateNEditHighSchool(model, model.ID.ToString());

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
        public async Task<IActionResult> DeleteHighSchool(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _highSchoolService.DeleteHighSchool(id);

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
        public async Task<IActionResult> GetAllHighSchoolsInJson(string type = "Public", int start = 0, int length = 100,int draw=1, string search = "")
        {
            try
            {
                // Retrieve list from the database
                List<HighSchoolVM> data = await _highSchoolService.GetAllHighSchool(type, start, length);
                int totalRecords = _context.HighSchool.Count();
                // Return result as JSON
                return Json(new
                {
                    draw = draw, // required parameter for jQuery DataTables
                    recordsTotal = totalRecords,
                    recordsFiltered = totalRecords,
                    data = data,
                });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}
