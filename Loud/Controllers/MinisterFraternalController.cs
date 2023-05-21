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
    public class MinisterFraternalController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MinisterFraternalController> _logger;
        private readonly IMinisterFraternal _ministerFraternalService;
        public MinisterFraternalController(ILogger<MinisterFraternalController> logger, ApplicationDbContext context, IMinisterFraternal ministerFraternalService)
        {
            _logger = logger;
            _ministerFraternalService = ministerFraternalService;
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
            ViewData["ChurchID"] = new SelectList(_context.Church, "ID", "Nm");
            return View();
        }


        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(MinisterFraternalVM model)
        {

            if (model.Nm != "")
            {

                //Saving the data in database
                ErrorVM error = await _ministerFraternalService.CreateNEditMinisterFraternal(model);

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
        public async Task<IActionResult> EditMinisterFraternal(string id)
        {

            if (id.IsNullOrWhiteSpace() == false)
            {

                //Saving the data in database
                MinisterFraternalVM data = await _ministerFraternalService.GetSingleMinisterFraternalWithSearch(id);

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
        public async Task<IActionResult> UpdateMinisterFraternal(MinisterFraternalVM model)
        {

            if (model.ID.ToString() != "" && model.Nm != "")
            {

                //Saving the data in database
                ErrorVM error = await _ministerFraternalService.CreateNEditMinisterFraternal(model, model.ID.ToString());

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
        public async Task<IActionResult> DeleteMinisterFraternal(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _ministerFraternalService.DeleteMinisterFraternal(id);

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
        public async Task<IActionResult> GetAllMinisterFraternalsInJson()
        {
            List<MinisterFraternalVM> data = await _ministerFraternalService.GetAllMinisterFraternal();
            return Json(new { data });
        }
    }
}
