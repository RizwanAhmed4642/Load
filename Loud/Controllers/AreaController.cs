using SAS.Common;
using SAS.Data;
using SAS.Interfaces;
using SAS.Models;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using Newtonsoft.Json;
using NUglify.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace SAS.Controllers
{
    public class AreaController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AreaController> _logger;
        private readonly IArea _areaService;
        public AreaController(ILogger<AreaController> logger, ApplicationDbContext context, IArea areaService)
        {
            _logger = logger;
            _areaService = areaService;
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
        public async Task<IActionResult> Create(AreaVM model)
        {

            if (model.Nm != "" && model.StartLat != 0 && model.StartLng != 0 && model.EndLat != 0 && model.EndLng != 0)
            {

                //Saving the data in database
                ErrorVM error = await _areaService.CreateNEditArea(model);

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
        public async Task<IActionResult> EditArea(string id)
        {

            if (id.IsNullOrWhiteSpace() ==false)
            {

                //Saving the data in database
                AreaVM data = await _areaService.GetSingleAreaWithSearch(id);

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
        public async Task<IActionResult> UpdateArea(AreaVM model)
        {

            if (model.ID.ToString() != "" && model.Nm != "" && model.StartLat != 0 && model.StartLng != 0 && model.EndLat != 0 && model.EndLng != 0)
            {

                //Saving the data in database
                ErrorVM error = await _areaService.CreateNEditArea(model, model.ID.ToString());

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
        public async Task<IActionResult> DeleteArea(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _areaService.DeleteArea(id);

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
        public async Task<IActionResult> GetAllAreasInJson()
        {
            List<Area> data = await _areaService.GetAllArea();
            return Json(new { data });
        }
    }
}
