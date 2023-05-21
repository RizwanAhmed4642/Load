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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAS.Controllers
{
    public class PrimarySchoolController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PrimarySchoolController> _logger;
        private readonly IPrimarySchool _primarySchoolService;
        public PrimarySchoolController(ILogger<PrimarySchoolController> logger, ApplicationDbContext context, IPrimarySchool primarySchoolService)
        {
            _logger = logger;
            _primarySchoolService = primarySchoolService;
            _context = context;
        }

        public IActionResult Index(string type = "Public", string hsID = "")
        {
            PrimarySchoolVM data = new PrimarySchoolVM();
            GlobalHelper gh = new GlobalHelper(_context);
            var subList = gh.GetSuburbsSelectListWithPostCode();
            if (hsID != "") data.HighSchoolID = Convert.ToInt32(hsID);
            if (type != "") data.type = type;
            ViewBag.btnSubmitFormText = "Create";
            ViewData["PrimarySchoolID"] = new SelectList(_context.PrimarySchool, "ID", "Nm");
            ViewData["HighSchoolID"] = new SelectList(_context.HighSchool, "ID", "Nm");
            ViewData["OverideID"] = new SelectList(_context.Overide, "ID", "Nm");
            ViewData["AreaID"] = new SelectList(_context.Area, "ID", "Nm");
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
        public IActionResult Create(string hsID="", string type = "")
        {
            PrimarySchoolVM data = new PrimarySchoolVM();
            GlobalHelper gh = new GlobalHelper(_context);
            var subList = gh.GetSuburbsSelectListWithPostCode();
            if (hsID != "")data.HighSchoolID = Convert.ToInt32(hsID);
            if (type != "")data.type = type;
            ViewBag.btnSubmitFormText = "Create";
            ViewData["PrimarySchoolID"] = new SelectList(_context.PrimarySchool, "ID", "Nm");
            ViewData["HighSchoolID"] = new SelectList(_context.HighSchool, "ID", "Nm");
            ViewData["OverideID"] = new SelectList(_context.Overide, "ID", "Nm");
            ViewData["AreaID"] = new SelectList(_context.Area, "ID", "Nm");
            ViewData["ChaplainID"] = new SelectList(_context.Chaplain, "ID", "Nm");
            ViewData["PASuburbID"] = subList;
            ViewData["SASuburbID"] = subList;
            ViewData["SREStatusID"] = new SelectList(_context.CurrentStatus, "ID", "Nm");
            ViewData["Type"] = gh.GetSchoolTypesSelectList();
            return View(data);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(PrimarySchoolVM model)
        {
            PrimarySchoolVM data = new PrimarySchoolVM();
            ViewBag.btnSubmitFormText = "Create";

            if (model.Nm != "" && model.StreetAddress != "" && model.Phone1 != "" && model.email != "")
            {

                //Saving the data in database
                ErrorVM error = await _primarySchoolService.CreateNEditPrimarySchool(model);

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
        public async Task<IActionResult> EditPrimarySchool(string id)
        {
            ViewBag.btnSubmitFormText = "Update";
            if (id.IsNullOrWhiteSpace() == false)
            {
                GlobalHelper gh = new GlobalHelper(_context);
                var subList = gh.GetSuburbsSelectListWithPostCode();
                ViewData["PrimarySchoolID"] = new SelectList(_context.PrimarySchool, "ID", "Nm");
                ViewData["HighSchoolID"] = new SelectList(_context.HighSchool, "ID", "Nm");
                ViewData["OverideID"] = new SelectList(_context.Overide, "ID", "Nm");
                ViewData["AreaID"] = new SelectList(_context.Area, "ID", "Nm");
                ViewData["ChaplainID"] = new SelectList(_context.Chaplain, "ID", "Nm");
                ViewData["PASuburbID"] = subList;
                ViewData["SASuburbID"] = subList;
                ViewData["SREStatusID"] = new SelectList(_context.CurrentStatus, "ID", "Nm");
                ViewData["Type"] = gh.GetSchoolTypesSelectList();

                //Saving the data in database
                PrimarySchoolVM data = await _primarySchoolService.GetSinglePrimarySchoolWithSearch(id);

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
                    return View("~/Views/PrimarySchool/Create.cshtml", data);
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
        public async Task<IActionResult> UpdatePrimarySchool(PrimarySchoolVM model)
        {
            PrimarySchoolVM data = new PrimarySchoolVM();
            ViewBag.btnSubmitFormText = "Update";
            if (model.Nm != "" && model.StreetAddress != "" && model.Phone1 != "" && model.email != "")
            {

                //Saving the data in database
                ErrorVM error = await _primarySchoolService.CreateNEditPrimarySchool(model, model.ID.ToString());

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
                    return View("~/Views/PrimarySchool/Create.cshtml", data);
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
        public async Task<IActionResult> DeletePrimarySchool(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _primarySchoolService.DeletePrimarySchool(id);

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
        public async Task<IActionResult> GetAllPrimarySchoolsInJson(string type = "Public")
        {
            List<PrimarySchoolVM> data = await _primarySchoolService.GetAllPrimarySchool(type);
            return Json(new { data });
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllPrimaryShcoolsWithHighSchool(string hsID)
        {
            List<PrimarySchoolVM> data = await _primarySchoolService.GetAllPrimaryShcoolsWithHighSchool(hsID);
            return Json(new { data });
        }
    }
}
