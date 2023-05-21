using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SAS.Controllers;
using SAS.Data;
using SAS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAS.Common
{
    public class GlobalHelper
    {
        private readonly ApplicationDbContext _context;
        public GlobalHelper(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<SelectListItem> GetSuburbsSelectListWithPostCode()
        {
            List<SelectListItem> suburbsList = _context.Suburb
                                                .Join(_context.State, sub => sub.StateID, st => st.ID, (sub, st) => new { Sub = sub, St = st })
                                                .Where(x => x.Sub.StateID == x.St.ID)
                                                .Select(x => new SelectListItem
                                                {
                                                    Value = x.Sub.ID.ToString(),
                                                    Text = x.Sub.Nm + " - " + x.St.Nm + " - " + x.Sub.PostCode
                                                })
                                                .ToList();
            return suburbsList;
        }
        public List<SelectListItem> GetSchoolTypesSelectList()
        {
            List<SelectListItem> schoolTypes = new List<SelectListItem>();
            schoolTypes.Add(new SelectListItem { Text = "Public", Value = "Public" });
            schoolTypes.Add(new SelectListItem { Text = "Private", Value = "Private" });
            schoolTypes.Add(new SelectListItem { Text = "Catholic", Value = "Catholic" });
            return schoolTypes;
        }
    }
}
