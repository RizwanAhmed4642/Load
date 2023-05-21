using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SAS.Models;
using SAS.Models.ViewModels.SuperAdminViewModels;
using SAS.Data;
using SAS.Models.ViewModels.SASViewModels;

namespace SAS.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserLogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserLogsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            List<UserAuditVM> dataList = (from uae in _context.UserAuditEvents
                                         join user in _userManager.Users on
                                         uae.UserId equals user.Id
                                         where uae.UserId == user.Id
                                         select new UserAuditVM
                                         {
                                             UserAuditId = uae.UserAuditId,
                                             UserId = user.Id,
                                             UserName = user.UserName,
                                             Timestamp = uae.Timestamp,
                                             AuditEvent = uae.AuditEvent,
                                             IpAddress = uae.IpAddress
                                         }).ToList();

            //var dataList = _context.UserAuditEvents.ToList()
            return View(dataList);
        }
    }
}
