using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class DBPrimarySchoolHandler : IPrimarySchool
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBPrimarySchoolHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ErrorVM> CreateNEditPrimarySchool(PrimarySchoolVM model, string id = "")
        {
            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<PrimarySchool>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.PrimarySchool.AddAsync(entity);
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
                    PrimarySchool entity = _mapper.Map<PrimarySchool>(model);
                    PrimarySchool updatedRecord = await _context.PrimarySchool.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.Nm = entity.Nm;
                        updatedRecord.StreetAddress = entity.StreetAddress;
                        updatedRecord.SASuburbID = entity.SASuburbID;
                        updatedRecord.PASameAsSA = entity.PASameAsSA;
                        updatedRecord.PostalAddress = entity.PostalAddress;
                        updatedRecord.PASuburbID = entity.PASuburbID;
                        updatedRecord.Phone1 = entity.Phone1;
                        updatedRecord.Phone2 = entity.Phone2;
                        updatedRecord.Fax = entity.Fax;
                        updatedRecord.email = entity.email;
                        updatedRecord.email2 = entity.email2;
                        updatedRecord.SchoolCode = entity.SchoolCode;
                        updatedRecord.HighSchoolID = entity.HighSchoolID;
                        updatedRecord.Principal = entity.Principal;
                        updatedRecord.Note = entity.Note;
                        updatedRecord.WebSite = entity.WebSite;
                        updatedRecord.IsCombinedWithSelectedHS = entity.IsCombinedWithSelectedHS;
                        updatedRecord.GeoStatusID = entity.GeoStatusID;
                        updatedRecord.GeoAccuracyID = entity.GeoAccuracyID;
                        updatedRecord.type = entity.type;
                        updatedRecord.Lat = entity.Lat;
                        updatedRecord.Lng = entity.Lng;
                        updatedRecord.LatLongSetByUser = entity.LatLongSetByUser;
                        updatedRecord.SREStatusID = entity.SREStatusID;
                        updatedRecord.OverideID = entity.OverideID;
                        updatedRecord.WantsNewsletter = entity.WantsNewsletter;
                        updatedRecord.AreaID = entity.AreaID;
                        updatedRecord.LockAreaID = entity.LockAreaID;
                        updatedRecord.SREBoardID = entity.SREBoardID;
                        updatedRecord.ChaplainID = entity.ChaplainID;
                        updatedRecord.Country = entity.Country;
                        updatedRecord.GooglePlusCode = entity.GooglePlusCode;
                        updatedRecord.MapLink = entity.MapLink;
                        updatedRecord.PostCode = entity.PostCode;
                        updatedRecord.PrincipalEmail = entity.PrincipalEmail;
                        updatedRecord.PrincipalPhone = entity.PrincipalPhone;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.PrimarySchool.Update(updatedRecord);
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

        public Task<ErrorVM> DeletePrimarySchool(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.PrimarySchool.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<PrimarySchoolVM>> GetAllPrimarySchool(string type = "Public")
        {
            try
            {
                // Retrieve list from the database
                List<PrimarySchoolVM> list = (from main in _context.PrimarySchool
                                              where main.type == type
                                              join sub in _context.Suburb on
                                              main.SASuburbID equals sub.ID
                                              where main.SASuburbID == sub.ID
                                              join st in _context.State on
                                              sub.StateID equals st.ID
                                              where sub.StateID == st.ID
                                              join ss in _context.CurrentStatus on
                                              main.SREStatusID equals ss.ID
                                              where main.SREStatusID == ss.ID
                                              join ga in _context.GeoAccuracy on
                                              main.GeoAccuracyID equals ga.ID into gaGroup
                                              from ga in gaGroup.DefaultIfEmpty()
                                              join tk in _context.Task on
                                              main.ID equals tk.VenueID into tkGroup
                                              from tk in tkGroup.DefaultIfEmpty()
                                              join user in _userManager.Users on
                                              tk.AssignToID equals user.Id into userGroup
                                              from user in userGroup.DefaultIfEmpty()
                                              select new PrimarySchoolVM
                                              {
                                                  ID = main.ID,
                                                  Nm = main.Nm,
                                                  Note = main.Note,
                                                  PostalAddress = main.PostalAddress,
                                                  type = main.type,
                                                  Phone1 = main.Phone1,
                                                  Phone2 = main.Phone2,
                                                  email = main.email,
                                                  email2 = main.email2,
                                                  PASuburbID = sub.ID,
                                                  PASuburbName = sub.Nm,
                                                  SASuburbID = sub.ID,
                                                  PostalCode = sub.PostCode,
                                                  SASuburbName = sub.Nm,
                                                  StreetAddress = main.StreetAddress,
                                                  StateID = st.ID,
                                                  StateName = st.Nm,
                                                  SREStatusID = ss.ID,
                                                  SREStatusName = ss.Nm,
                                                  GeoAccuracyID = ga.ID,
                                                  GeoAccuracyName = ga.GoogleMeaning,
                                                  NextTaskDoBy = user.FirstName,
                                                  TaskSubject = tk.Subject,
                                                  Country = main.Country,
                                                  GooglePlusCode = main.GooglePlusCode,
                                                  MapLink = main.MapLink,
                                                  PostCode = main.PostCode,
                                                  PrincipalEmail = main.PrincipalEmail,
                                                  PrincipalPhone = main.PrincipalPhone,
                                                  Days = ConvertDateToDays(tk.StartDate),
                                                  EmailFlag = (main.email != null && main.email != "") ? "Y" : "N",
                                                  LastInfoSent = tk.StartDate.ToString(),
                                                  AssociatedHighSchool = _context.HighSchool.Where(x => x.ID == main.ID).Count().ToString(),
                                                  AssociatedChurch = _context.Church.Where(x => x.HighSchoolID == main.ID).Count().ToString(),
                                                  Fax = main.Fax,
                                                  SchoolCode = main.SchoolCode,
                                                  HighSchoolID = main.HighSchoolID,
                                                  Principal = main.Principal,
                                                  WebSite = main.WebSite,
                                                  IsCombinedWithSelectedHS = main.IsCombinedWithSelectedHS,
                                                  GeoStatusID = main.GeoStatusID,
                                                  Lat = main.Lat,
                                                  Lng = main.Lng,
                                                  LatLongSetByUser = main.LatLongSetByUser,
                                                  OverideID = main.OverideID,
                                                  WantsNewsletter = main.WantsNewsletter,
                                                  LockAreaID = main.LockAreaID,
                                                  ChaplainID = main.ChaplainID,
                                              }).ToList();

                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<PrimarySchoolVM>>(null);
            }
        }
        private static string ConvertDateToDays(DateTime? d1)
        {
            DateTime d2 = DateTime.Now;
            return Convert.ToInt32((d2 - d1)?.TotalDays).ToString();
        }
        public Task<List<PrimarySchoolVM>> GetAllPrimaryShcoolsWithHighSchool(string hsID)
        {
            int hsid = Convert.ToInt32(hsID);
            try
            {
                // Retrieve list from the database
                List<PrimarySchoolVM> list = (from ps in _context.PrimarySchool
                                              join hs in _context.HighSchool on ps.HighSchoolID equals hs.ID
                                              where ps.HighSchoolID == hsid
                                              select new PrimarySchoolVM
                                              {
                                                  ID = ps.ID,
                                                  Nm = ps.Nm,
                                                  Note = ps.Note,
                                              }).ToList();
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<PrimarySchoolVM>>(null);
            }
        }

        public Task<PrimarySchoolVM> GetSinglePrimarySchoolWithSearch(string id)
        {

            try
            {
                //Check collection is not empty before using the First method.
                if (_context.PrimarySchool.Any(a => a.ID.ToString() == id))
                {
                    PrimarySchool mdoel = _context.PrimarySchool.First(a => a.ID.ToString() == id);
                    PrimarySchoolVM data = _mapper.Map<PrimarySchoolVM>(mdoel);
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
