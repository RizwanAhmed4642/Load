using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NUglify.Helpers;
using SAS.Data;
using SAS.DBFirst;
using SAS.GeneralLayer;
using SAS.Interfaces;
using SAS.Models;
using SAS.Models.SASModels;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAS.Controllers
{
    public class EmailController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly SasContext _dbcontext;
        private readonly ILogger<EmailController> _logger;
        private readonly IEmail _emailService;
        private readonly IEmailSender _emailSender;
        // Inject IWebHostEnvironment in your controller
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmailController(ILogger<EmailController> logger, ApplicationDbContext context, IEmail emailService, IEmailSender emailSender, IWebHostEnvironment webHostEnvironment, SasContext dbcontext)
        {
            _logger = logger;
            _emailService = emailService;
            _emailSender = emailSender;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Create(string email = "")
        {
            EmailVM data = new EmailVM();
            byte[] dataEnc = Convert.FromBase64String(email);
            string newEmail = Encoding.UTF8.GetString(dataEnc);
            data.ToEmail = newEmail;
            ViewBag.btnSubmitFormText = "Send";
            return View(data);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(EmailVM model)
        {
            EmailVM data = new EmailVM();
            string FromEmail = "";
            ViewBag.btnSubmitFormText = "Send";
            List<string> attachmentPaths = new List<string>();
            string attachmentPathsNames = "";
            // Save the attachments to temporary files
            foreach (var attachment in model.Attachments)
            {
                var attachmentFileName = $"{Guid.NewGuid()}{Path.GetExtension(attachment.FileName)}";
                var attachmentPath = Path.Combine(_webHostEnvironment.WebRootPath, "temp", attachmentFileName);

                using (var stream = new FileStream(attachmentPath, FileMode.Create))
                {
                    await attachment.CopyToAsync(stream);
                }
                attachmentPathsNames += attachmentPath + "<br>";
                attachmentPaths.Add(attachmentPath);
            }

            if (model.ToEmail != "" && model.Subject != "" && model.Body != "")
            {
                ErrorVM error = new ErrorVM();
                if (model.EmailToGroup.Equals("High Schools"))
                {
                    List<Models.HighSchool> hsList = _context.HighSchool.ToList();
                    foreach (var item in hsList)
                    {
                        if (SecurityLayer.ValidateEmailAddress(item.email))
                        {
                            await _emailSender.SendOTPEmailAsync(item.email, model.Body, out FromEmail, model.Subject, attachmentPaths);
                            model.FromEmail = FromEmail;
                            model.ToEmail = item.email;
                            model.Body += "<br><br> Attachment Paths <br>" + attachmentPathsNames;
                            //Saving the data in database
                            error = await _emailService.CreateNEditEmail(model);
                        }
                        if (SecurityLayer.ValidateEmailAddress(item.email2))
                        {
                            await _emailSender.SendOTPEmailAsync(item.email2, model.Body, out FromEmail, model.Subject, attachmentPaths);
                            model.FromEmail = FromEmail;
                            model.ToEmail = item.email2;
                            model.Body += "<br><br> Attachment Paths <br>" + attachmentPathsNames;
                            //Saving the data in database
                            error = await _emailService.CreateNEditEmail(model);
                        }
                    }
                }
                else if (model.EmailToGroup.Equals("Primary Schools"))
                {
                    List<Models.PrimarySchool> hsList = _context.PrimarySchool.ToList();
                    foreach (var item in hsList)
                    {
                        if (SecurityLayer.ValidateEmailAddress(item.email))
                        {
                            await _emailSender.SendOTPEmailAsync(item.email, model.Body, out FromEmail, model.Subject, attachmentPaths);
                            model.FromEmail = FromEmail;
                            model.ToEmail = item.email;
                            model.Body += "<br><br> Attachment Paths <br>" + attachmentPathsNames;
                            //Saving the data in database
                            error = await _emailService.CreateNEditEmail(model);
                        }
                        if (SecurityLayer.ValidateEmailAddress(item.email2))
                        {
                            await _emailSender.SendOTPEmailAsync(item.email2, model.Body, out FromEmail, model.Subject, attachmentPaths);
                            model.FromEmail = FromEmail;
                            model.ToEmail = item.email2;
                            model.Body += "<br><br> Attachment Paths <br>" + attachmentPathsNames;
                            //Saving the data in database
                            error = await _emailService.CreateNEditEmail(model);
                        }
                    }
                }
                else if (model.EmailToGroup.Equals("Churches"))
                {
                    List<Models.Church> hsList = _context.Church.ToList();
                    foreach (var item in hsList)
                    {
                        if (SecurityLayer.ValidateEmailAddress(item.email))
                        {
                            await _emailSender.SendOTPEmailAsync(item.email, model.Body, out FromEmail, model.Subject, attachmentPaths);
                            model.FromEmail = FromEmail;
                            model.ToEmail = item.email;
                            model.Body += "<br><br> Attachment Paths <br>" + attachmentPathsNames;
                            //Saving the data in database
                            error = await _emailService.CreateNEditEmail(model);
                        }
                        if (SecurityLayer.ValidateEmailAddress(item.email2))
                        {
                            await _emailSender.SendOTPEmailAsync(item.email2, model.Body, out FromEmail, model.Subject, attachmentPaths);
                            model.FromEmail = FromEmail;
                            model.ToEmail = item.email2;
                            model.Body += "<br><br> Attachment Paths <br>" + attachmentPathsNames;
                            //Saving the data in database
                            error = await _emailService.CreateNEditEmail(model);
                        }
                    }
                }
                else
                {
                    char[] delimiterChars = { ',', '|', ' ', ':', ';' };
                    string[] emails = model.ToEmail.Split(delimiterChars);
                    foreach (string toEmail in emails)
                    {
                        await _emailSender.SendOTPEmailAsync(toEmail, model.Body, out FromEmail, model.Subject, attachmentPaths);
                        model.FromEmail = FromEmail;
                        model.ToEmail = toEmail;
                        model.Body += "<br><br> Attachment Paths <br>" + attachmentPathsNames;
                        //Saving the data in database
                        error = await _emailService.CreateNEditEmail(model);
                    }
                }
                //// Delete temporary files
                //foreach (var attachmentPath in attachmentPaths)
                //{
                //    var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, "temp", Path.GetFileName(attachmentPath));
                //    if (System.IO.File.Exists(fullPath))
                //    {
                //        System.IO.File.Delete(fullPath);
                //    }
                //}

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
        public IActionResult DemoEmail(string email = "")
        {
            ViewBag.Users = new SelectList(_context.Users.ToList(), "Id", "FirstName");
            EmailVM data = new EmailVM();
            byte[] dataEnc = Convert.FromBase64String(email);
            string newEmail = Encoding.UTF8.GetString(dataEnc);
            data.ToEmail = newEmail;
            ViewBag.btnSubmitFormText = "Send";
            return View(data);
        }
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> DemoEmail(EmailVM model)
        {
            return Json(new { success = true, flag = "success" });
                     
        }

        //[HttpPost]
        ////[Authorize]
        //public async Task<IActionResult> DemoEmail(EmailVM model)
        //{
        //    EmailVM data = new EmailVM();
        //    string FromEmail = "";
        //    ViewBag.btnSubmitFormText = "Send";
        //    List<string> attachmentPaths = new List<string>();
        //    string attachmentPathsNames = "";
        //    // Save the attachments to temporary files
        //    foreach (var attachment in model.Attachments)
        //    {
        //        var attachmentFileName = $"{Guid.NewGuid()}{Path.GetExtension(attachment.FileName)}";
        //        var attachmentPath = Path.Combine(_webHostEnvironment.WebRootPath, "temp", attachmentFileName);

        //        using (var stream = new FileStream(attachmentPath, FileMode.Create))
        //        {
        //            await attachment.CopyToAsync(stream);
        //        }
        //        attachmentPathsNames += attachmentPath + "<br>";
        //        attachmentPaths.Add(attachmentPath);
        //    }

        //    if (model.ToEmail != "" && model.Subject != "" && model.Body != "")
        //    {
        //        ErrorVM error = new ErrorVM();
        //        if (model.EmailToGroup.Equals("High Schools"))
        //        {
        //            List<Models.HighSchool> hsList = _context.HighSchool.ToList();
        //            foreach (var item in hsList)
        //            {
        //                if (SecurityLayer.ValidateEmailAddress(item.email))
        //                {
        //                    await _emailSender.SendOTPEmailAsync(item.email, model.Body, out FromEmail, model.Subject, attachmentPaths);
        //                    model.FromEmail = FromEmail;
        //                    model.ToEmail = item.email;
        //                    model.Body += "<br><br> Attachment Paths <br>" + attachmentPathsNames;
        //                    //Saving the data in database
        //                    error = await _emailService.CreateNEditEmail(model);
        //                }
        //                if (SecurityLayer.ValidateEmailAddress(item.email2))
        //                {
        //                    await _emailSender.SendOTPEmailAsync(item.email2, model.Body, out FromEmail, model.Subject, attachmentPaths);
        //                    model.FromEmail = FromEmail;
        //                    model.ToEmail = item.email2;
        //                    model.Body += "<br><br> Attachment Paths <br>" + attachmentPathsNames;
        //                    //Saving the data in database
        //                    error = await _emailService.CreateNEditEmail(model);
        //                }
        //            }
        //        }
        //        else if (model.EmailToGroup.Equals("Primary Schools"))
        //        {
        //            List<Models.PrimarySchool> hsList = _context.PrimarySchool.ToList();
        //            foreach (var item in hsList)
        //            {
        //                if (SecurityLayer.ValidateEmailAddress(item.email))
        //                {
        //                    await _emailSender.SendOTPEmailAsync(item.email, model.Body, out FromEmail, model.Subject, attachmentPaths);
        //                    model.FromEmail = FromEmail;
        //                    model.ToEmail = item.email;
        //                    model.Body += "<br><br> Attachment Paths <br>" + attachmentPathsNames;
        //                    //Saving the data in database
        //                    error = await _emailService.CreateNEditEmail(model);
        //                }
        //                if (SecurityLayer.ValidateEmailAddress(item.email2))
        //                {
        //                    await _emailSender.SendOTPEmailAsync(item.email2, model.Body, out FromEmail, model.Subject, attachmentPaths);
        //                    model.FromEmail = FromEmail;
        //                    model.ToEmail = item.email2;
        //                    model.Body += "<br><br> Attachment Paths <br>" + attachmentPathsNames;
        //                    //Saving the data in database
        //                    error = await _emailService.CreateNEditEmail(model);
        //                }
        //            }
        //        }
        //        else if (model.EmailToGroup.Equals("Churches"))
        //        {
        //            List<Models.Church> hsList = _context.Church.ToList();
        //            foreach (var item in hsList)
        //            {
        //                if (SecurityLayer.ValidateEmailAddress(item.email))
        //                {
        //                    await _emailSender.SendOTPEmailAsync(item.email, model.Body, out FromEmail, model.Subject, attachmentPaths);
        //                    model.FromEmail = FromEmail;
        //                    model.ToEmail = item.email;
        //                    model.Body += "<br><br> Attachment Paths <br>" + attachmentPathsNames;
        //                    //Saving the data in database
        //                    error = await _emailService.CreateNEditEmail(model);
        //                }
        //                if (SecurityLayer.ValidateEmailAddress(item.email2))
        //                {
        //                    await _emailSender.SendOTPEmailAsync(item.email2, model.Body, out FromEmail, model.Subject, attachmentPaths);
        //                    model.FromEmail = FromEmail;
        //                    model.ToEmail = item.email2;
        //                    model.Body += "<br><br> Attachment Paths <br>" + attachmentPathsNames;
        //                    //Saving the data in database
        //                    error = await _emailService.CreateNEditEmail(model);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            char[] delimiterChars = { ',', '|', ' ', ':', ';' };
        //            string[] emails = model.ToEmail.Split(delimiterChars);
        //            foreach (string toEmail in emails)
        //            {
        //                await _emailSender.SendOTPEmailAsync(toEmail, model.Body, out FromEmail, model.Subject, attachmentPaths);
        //                model.FromEmail = FromEmail;
        //                model.ToEmail = toEmail;
        //                model.Body += "<br><br> Attachment Paths <br>" + attachmentPathsNames;
        //                //Saving the data in database
        //                error = await _emailService.CreateNEditEmail(model);
        //            }
        //        }
        //        //// Delete temporary files
        //        //foreach (var attachmentPath in attachmentPaths)
        //        //{
        //        //    var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, "temp", Path.GetFileName(attachmentPath));
        //        //    if (System.IO.File.Exists(fullPath))
        //        //    {
        //        //        System.IO.File.Delete(fullPath);
        //        //    }
        //        //}

        //        // If the header is set to "XMLHttpRequest", it indicates that the request was made using AJAX.
        //        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //        {
        //            if (error.Status)
        //                return Json(new { success = true, message = error.Message, flag = "success" });
        //            else
        //                return Json(new { success = false, message = error.Message, flag = "error" });
        //        }
        //        // Otherwise return the html response
        //        else
        //            return View(data);
        //    }
        //    else if (ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    else
        //        return View();
        //}

        [HttpGet]
        public IActionResult GetUserArea(string id = "")
        {
            var userarea = _dbcontext.UserwithUserAreas.Where(x => x.UserId == id).ToList();
            return Json(new {data = userarea });


        }
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> EditEmail(string id)
        {
            ViewBag.btnSubmitFormText = "Update";
            if (id.IsNullOrWhiteSpace() == false)
            {
                //Saving the data in database
                EmailVM data = await _emailService.GetSingleEmailWithSearch(id);

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
                    return View("~/Views/Email/Create.cshtml", data);
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
        public async Task<IActionResult> UpdateEmail(EmailVM model)
        {
            ViewBag.btnSubmitFormText = "Update";
            if (model.ToEmail != "" && model.Subject != "" && model.Body != "")
            {

                //Saving the data in database
                ErrorVM error = await _emailService.CreateNEditEmail(model, model.ID.ToString());

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
        public async Task<IActionResult> DeleteEmail(string id)
        {

            if (id != "")
            {

                //Saving the data in database
                ErrorVM error = await _emailService.DeleteEmail(id);

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
        public async Task<IActionResult> GetAllEmailsInJson()
        {
            List<EmailVM> data = await _emailService.GetAllEmail();
            return Json(new { data });
        }
    }
}
