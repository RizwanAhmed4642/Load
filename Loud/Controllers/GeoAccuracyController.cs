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
    public class GeoAccuracyController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<GeoAccuracyController> _logger;
        private readonly IGeoAccuracy _geoAccuracyService;
        public GeoAccuracyController(ILogger<GeoAccuracyController> logger, ApplicationDbContext context, IGeoAccuracy geoAccuracyService)
        {
            _logger = logger;
            _geoAccuracyService = geoAccuracyService;
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
        public async Task<IActionResult> Create(GeoAccuracyVM model)
        {

            if (model.GoogleMeaning != "")
            {

                //Saving the data in database
                ErrorVM error = await _geoAccuracyService.CreateNEditGeoAccuracy(model);

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
        public async Task<IActionResult> EditGeoAccuracy(string id)
        {

            if (id.IsNullOrWhiteSpace() == false)
            {

                //Saving the data in database
                GeoAccuracyVM data = await _geoAccuracyService.GetSingleGeoAccuracyWithSearch(id);

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
        public async Task<IActionResult> UpdateGeoAccuracy(GeoAccuracyVM model)
        {

            if (model.GoogleMeaning != "")
            {

                //Saving the data in database
                ErrorVM error = await _geoAccuracyService.CreateNEditGeoAccuracy(model, model.ID.ToString());

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
        public async Task<IActionResult> DeleteGeoAccuracy(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _geoAccuracyService.DeleteGeoAccuracy(id);

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
        public async Task<IActionResult> GetAllGeoAccuracysInJson()
        {
            List<GeoAccuracyVM> data = await _geoAccuracyService.GetAllGeoAccuracy();
            return Json(new { data });
        }
    }
}
