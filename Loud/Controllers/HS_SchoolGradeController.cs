using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NUglify.Helpers;
using SAS.Data;
using SAS.Interfaces;
using SAS.Models;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Controllers
{
    public class HS_SchoolGradeController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HS_SchoolGradeController> _logger;
        private readonly IHS_SchoolGrade _hs_SchoolGradeService;
        public HS_SchoolGradeController(ILogger<HS_SchoolGradeController> logger, ApplicationDbContext context, IHS_SchoolGrade hs_SchoolGradeService)
        {
            _logger = logger;
            _hs_SchoolGradeService = hs_SchoolGradeService;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Create(string hsID = "")
        {
            HS_SchoolGradeVM data = new HS_SchoolGradeVM();
            if (hsID != "")
                data.HSID = Convert.ToInt32(hsID);
            ViewData["HSID"] = new SelectList(_context.HighSchool, "ID", "Nm");
            ViewData["SchoolGradeID"] = new SelectList(_context.SchoolGrade, "ID", "Nm");
            return View(data);
        }


        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(HS_SchoolGradeVM model)
        {

            if (model.HSID != null && model.SchoolGradeID != null)
            {

                //Saving the data in database
                ErrorVM error = await _hs_SchoolGradeService.CreateNEditHS_SchoolGrade(model);

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
        public async Task<IActionResult> EditHS_SchoolGrade(string id)
        {

            if (id.IsNullOrWhiteSpace() == false)
            {

                //Saving the data in database
                HS_SchoolGradeVM data = await _hs_SchoolGradeService.GetSingleHS_SchoolGradeWithSearch(id);

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
        public async Task<IActionResult> UpdateHS_SchoolGrade(HS_SchoolGradeVM model)
        {

            if (model.ID.ToString() != "" && model.HSID != null && model.SchoolGradeID != null)
            {

                //Saving the data in database
                ErrorVM error = await _hs_SchoolGradeService.CreateNEditHS_SchoolGrade(model, model.ID.ToString());

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
        public async Task<IActionResult> DeleteHS_SchoolGrade(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _hs_SchoolGradeService.DeleteHS_SchoolGrade(id);

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
        public async Task<IActionResult> GetAllHS_SchoolGradesInJson()
        {
            List<HS_SchoolGradeVM> data = await _hs_SchoolGradeService.GetAllHS_SchoolGrade();
            return Json(new { data });
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllHSGWithHighSchool(string hsID)
        {
            List<HS_SchoolGradeVM> data = await _hs_SchoolGradeService.GetAllHSGWithHighSchool(hsID);
            return Json(new { data });
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllHSGWithPrimarySchool(string hsID)
        {
            List<HS_SchoolGradeVM> data = await _hs_SchoolGradeService.GetAllHSGWithHighSchool(hsID);
            return Json(new { data });
        }
    }
}
