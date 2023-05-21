using AutoMapper;
using Microsoft.AspNetCore.Http;
using SAS.Data;
using SAS.Interfaces;
using SAS.Models;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace SAS.BusinessLayer
{
    public class DBHS_SchoolGradeHandler : IHS_SchoolGrade
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBHS_SchoolGradeHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditHS_SchoolGrade(HS_SchoolGradeVM model, string id = "")
        {

            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<HS_SchoolGrade>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.HS_SchoolGrade.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    return new ErrorVM { Status = true, ErrorCode = "200", Message = "Saved Successfully" };
                }
                catch (Exception exe)
                {
                    return new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message };
                }
            }
            else if (id != "")
            {
                try
                {
                    HS_SchoolGrade entity = _mapper.Map<HS_SchoolGrade>(model);
                    HS_SchoolGrade updatedRecord = await _context.HS_SchoolGrade.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.HSID = entity.HSID;
                        updatedRecord.SchoolGradeID = entity.SchoolGradeID;
                        updatedRecord.SASTT = entity.SASTT;
                        updatedRecord.SRETT = entity.SRETT;
                        updatedRecord.Seminar = entity.Seminar;
                        updatedRecord.None = entity.None;
                        updatedRecord.Deleted = entity.Deleted;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.HS_SchoolGrade.Update(updatedRecord);
                        await _context.SaveChangesAsync();
                    }

                    return new ErrorVM { Status = true, ErrorCode = "200", Message = "Updated Successfully" };
                }
                catch (Exception exe)
                {
                    return new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message };
                }
            }
            else
            {
                return new ErrorVM { Status = false, ErrorCode = "404", Message = "Something went wrong." };
            }
        }

        public Task<ErrorVM> DeleteHS_SchoolGrade(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.HS_SchoolGrade.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<HS_SchoolGradeVM>> GetAllHS_SchoolGrade()
        {
            try
            {
                // Retrieve list from the database
                List<HS_SchoolGradeVM> list = (from hsg in _context.HS_SchoolGrade
                                               join sg in _context.SchoolGrade on
                                               hsg.SchoolGradeID equals sg.ID
                                               where hsg.SchoolGradeID == sg.ID
                                               join hs in _context.HighSchool on
                                               hsg.HSID equals hs.ID
                                               where hsg.HSID == hs.ID
                                               select new HS_SchoolGradeVM
                                               {
                                                   ID = hsg.ID,
                                                   HSID = hs.ID,
                                                   HSName = hs.Nm,
                                                   SchoolGradeID = sg.ID,
                                                   SchoolGradeName = sg.Nm,
                                                   SASTT = hsg.SASTT,
                                                   SRETT = hsg.SRETT,
                                                   Seminar = hsg.Seminar,
                                                   None = hsg.None,
                                                   Deleted = hsg.Deleted,
                                               }).ToList();

                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<HS_SchoolGradeVM>>(null);
            }
        }

        public Task<List<HS_SchoolGradeVM>> GetAllHSGWithHighSchool(string hsID)
        {
            int hsid = Convert.ToInt32(hsID);
            try
            {
                // Retrieve list from the database
                List<HS_SchoolGradeVM> list = (from hsg in _context.HS_SchoolGrade
                                               join hs in _context.HighSchool on hsg.HSID equals hs.ID
                                               where hsg.HSID == hsid
                                               join sg in _context.SchoolGrade on hsg.SchoolGradeID equals sg.ID
                                               where hsg.SchoolGradeID == sg.ID
                                               select new HS_SchoolGradeVM
                                               {
                                                   ID = hsg.ID,
                                                   HSID = hs.ID,
                                                   HSName = hs.Nm,
                                                   SchoolGradeID = sg.ID,
                                                   SchoolGradeName = sg.Nm,
                                                   SASTT = hsg.SASTT,
                                                   SRETT = hsg.SRETT,
                                                   Seminar = hsg.Seminar,
                                                   None = hsg.None,
                                                   Deleted = hsg.Deleted,
                                               }).ToList();
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<HS_SchoolGradeVM>>(null);
            }
        }

        public Task<List<HS_SchoolGradeVM>> GetAllHSGWithPrimarySchool(string psID)
        {
            int hsid = Convert.ToInt32(psID);
            try
            {
                // Retrieve list from the database
                List<HS_SchoolGradeVM> list = (from hsg in _context.HS_SchoolGrade
                                               join ps in _context.PrimarySchool on hsg.HSID equals ps.ID
                                               where hsg.HSID == hsid
                                               join sg in _context.SchoolGrade on hsg.SchoolGradeID equals sg.ID
                                               where hsg.SchoolGradeID == sg.ID
                                               select new HS_SchoolGradeVM
                                               {
                                                   ID = hsg.ID,
                                                   HSID = ps.ID,
                                                   HSName = ps.Nm,
                                                   SchoolGradeID = sg.ID,
                                                   SchoolGradeName = sg.Nm,
                                                   SASTT = hsg.SASTT,
                                                   SRETT = hsg.SRETT,
                                                   Seminar = hsg.Seminar,
                                                   None = hsg.None,
                                                   Deleted = hsg.Deleted,
                                               }).ToList();
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<HS_SchoolGradeVM>>(null);
            }
        }

        public Task<HS_SchoolGradeVM> GetSingleHS_SchoolGradeWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.HS_SchoolGrade.Any(a => a.ID.ToString() == id))
                {
                    HS_SchoolGrade mdoel = _context.HS_SchoolGrade.First(a => a.ID.ToString() == id);
                    HS_SchoolGradeVM data = _mapper.Map<HS_SchoolGradeVM>(mdoel);
                    return Task.FromResult(data);
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
