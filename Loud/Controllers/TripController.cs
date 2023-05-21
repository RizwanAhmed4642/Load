using SAS.Data;
using SAS.Interfaces;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NUglify.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Controllers
{
    public class TripController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TripController> _logger;
        private readonly ITrip _tripService;
        public TripController(ILogger<TripController> logger, ApplicationDbContext context, ITrip tripService)
        {
            _logger = logger;
            _tripService = tripService;
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
            ViewData["SRERepID"] = new SelectList(_context.SRERep, "ID", "FirstName");
            
            return View();
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(TripVM model)
        {

            if (model.Subject != "" && model.StartDate != null && model.SRERepID != null)
            {

                //Saving the data in database
                ErrorVM error = await _tripService.CreateNEditTrip(model);

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
        public async Task<IActionResult> EditTrip(string id)
        {

            if (id.IsNullOrWhiteSpace() == false)
            {

                //Saving the data in database
                TripVM data = await _tripService.GetSingleTripWithSearch(id);

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
        public async Task<IActionResult> UpdateTrip(TripVM model)
        {

            if (model.Subject != "" && model.StartDate != null && model.SRERepID != null)
            {

                //Saving the data in database
                ErrorVM error = await _tripService.CreateNEditTrip(model, model.ID.ToString());

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
        public async Task<IActionResult> DeleteTrip(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _tripService.DeleteTrip(id);

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
        public async Task<IActionResult> GetAllTripsInJson()
        {
            List<TripVM> data = await _tripService.GetAllTrip();
            return Json(new { data });
        }
    }
}
