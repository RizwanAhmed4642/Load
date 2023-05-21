using SAS.Data;
using SAS.Interfaces;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NUglify.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Controllers
{
    public class MinisterController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MinisterController> _logger;
        private readonly IMinister _MinisterService;
        public MinisterController(ILogger<MinisterController> logger, ApplicationDbContext context, IMinister MinisterService)
        {
            _logger = logger;
            _MinisterService = MinisterService;
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
            ViewData["SASuburbID"] = new SelectList(_context.Suburb, "ID", "Nm");
            return View();
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(MinisterVM model)
        {

            if (model.FirstName != "" && model.Phone1 != "" && model.email != "")
            {

                //Saving the data in database
                ErrorVM error = await _MinisterService.CreateNEditMinister(model);

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
        public async Task<IActionResult> EditMinister(string id)
        {

            if (id.IsNullOrWhiteSpace() == false)
            {

                //Saving the data in database
                MinisterVM data = await _MinisterService.GetSingleMinisterWithSearch(id);

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
        public async Task<IActionResult> UpdateMinister(MinisterVM model)
        {

            if (model.ID.ToString() != "" && model.FirstName != "" && model.Phone1 != "" && model.email != "")
            {

                //Saving the data in database
                ErrorVM error = await _MinisterService.CreateNEditMinister(model, model.ID.ToString());

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
        public async Task<IActionResult> DeleteMinister(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _MinisterService.DeleteMinister(id);

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
        public async Task<IActionResult> GetAllMinistersInJson()
        {
            List<MinisterVM> data = await _MinisterService.GetAllMinister();
            return Json(new { data });
        }
    }
}
