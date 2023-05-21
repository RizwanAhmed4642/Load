using SAS.Controllers;
using SAS.Data;
using SAS.Models;
using SAS.Models.ViewModels.GeneralViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NUglify.Helpers;
using SAS.Interfaces;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Linq;

namespace SAS.Controllers
{
    public class TaskController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TaskController> _logger;
        private readonly ITask _TaskService;
        private readonly UserManager<ApplicationUser> _userManager;
        public TaskController(ILogger<TaskController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context, ITask TaskService)
        {
            _logger = logger;
            _TaskService = TaskService;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Create(string sVenueID="",string sVenueType="")
        {
            ViewData["TaskTypeID"] = new SelectList(_context.TaskType, "ID", "Nm");
            ViewData["TripID"] = new SelectList(_context.Trip, "ID", "Subject");
            // Define a list of Venue Types
            List<string> venueTypesList = new List<string> { "High School", //venueTypeID=0
                                                             "Primary School", //venueTypeID=1
                                                             //"Private High", 
                                                             //"Private Primary", 
                                                             //"Public High", 
                                                             //"Public Primary", 
                                                             "Church" //venueTypeID=2
                                                            };
            // Create a list of SelectListItem for each color
            List<SelectListItem> htmlOptions = new List<SelectListItem>();
            for (int i=0;i<venueTypesList.Count;i++)
            {
                htmlOptions.Add(new SelectListItem
                {
                    Text = venueTypesList[i],
                    Value = i.ToString()
                });
            }
            TaskVM model = new TaskVM();
            if(sVenueID!="")
            {
                model.VenueTypeID = venueTypesList.FindIndex(x => x.Equals(sVenueType, StringComparison.OrdinalIgnoreCase));
                model.VenueID = Convert.ToInt32(sVenueID);
            }
            else
            {
                model.VenueTypeID = 0;
                model.VenueID = 0;
            }
            // Create a SelectList with the list of color options
            ViewData["VenueTypeID"] = new SelectList(htmlOptions, "Value", "Text");
            ViewData["VenueID"] = new SelectList(_context.HighSchool, "ID", "Nm");
            ViewData["AssignToID"] = new SelectList(_userManager.Users, "Id", "FirstName");
            return View(model);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(TaskVM model)
        {

            if (model.TripID != null && model.VenueID != null && model.TaskTypeID != null && model.StartDate != null && model.Subject != null && model.AssignToID != null)
            {

                //Saving the data in database
                ErrorVM error = await _TaskService.CreateNEditTask(model);

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
        public async Task<IActionResult> EditTask(string id)
        {

            if (id.IsNullOrWhiteSpace() == false)
            {

                //Saving the data in database
                TaskVM data = await _TaskService.GetSingleTaskWithSearch(id);

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
        public async Task<IActionResult> UpdateTask(TaskVM model)
        {

            if (model.TripID != null && model.VenueID != null && model.TaskTypeID != null && model.StartDate != null && model.Subject != null && model.AssignToID != null)
            {

                //Saving the data in database
                ErrorVM error = await _TaskService.CreateNEditTask(model, model.ID.ToString());

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
        public async Task<IActionResult> DeleteTask(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _TaskService.DeleteTask(id);

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
        public async Task<IActionResult> GetAllTasksInJson()
        {
            List<TaskVM> data = await _TaskService.GetAllTask();
            return Json(new { data });
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllTasksWithHighSchool(string hsID, string venueTypeID)
        {
            List<TaskVM> data = await _TaskService.GetAllTasksWithHighSchool(hsID, venueTypeID);
            return Json(new { data });
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllTasksWithPrimarySchool(string hsID, string venueTypeID)
        {
            List<TaskVM> data = await _TaskService.GetAllTasksWithHighSchool(hsID, venueTypeID);
            return Json(new { data });
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllTasksWithChurch(string cID, string venueTypeID)
        {
            List<TaskVM> data = await _TaskService.GetAllTasksWithChurch(cID, venueTypeID);
            return Json(new { data });
        }
        [HttpGet]
        //[Authorize]
        public IActionResult GetVenueItemsBasedOnVenueType(string venueType = "")
        {
            List<SelectListItem> data = new List<SelectListItem>();
            if (venueType == "High School")
            {
                data = new SelectList(_context.HighSchool, "ID", "Nm").ToList();
            }
            else if (venueType == "Primary School")
            {
                data = new SelectList(_context.PrimarySchool, "ID", "Nm").ToList();
            }
            else if (venueType == "Church")
            {
                data = new SelectList(_context.Church, "ID", "Nm").ToList();
            }
            else
            {
                data = new SelectList(_context.HighSchool, "ID", "Nm").ToList();
            }
            return Json(new { data });
        }
    }
}
