using SAS.Data;
using SAS.Interfaces;
using SAS.Models;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Differencing;

namespace SAS.BusinessLayer
{
    public class DBHighSchoolHandler : IHighSchool
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBHighSchoolHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ErrorVM> CreateNEditHighSchool(HighSchoolVM model, string id = "")
        {
            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<HighSchool>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.HighSchool.AddAsync(entity);
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
                    HighSchool entity = _mapper.Map<HighSchool>(model);
                    HighSchool updatedRecord = await _context.HighSchool.FindAsync(model.ID);

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
                        updatedRecord.Principal = entity.Principal;
                        updatedRecord.Note = entity.Note;
                        updatedRecord.WebSite = entity.WebSite;
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
                        _context.HighSchool.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteHighSchool(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.HighSchool.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<HighSchoolVM>> GetAllHighSchool(string type = "Public", int start = 0, int length = 100,string search="")
        {
            try
            {
                // Retrieve list from the database
                List<HighSchoolVM> list = (from hs in _context.HighSchool
                                           where hs.type == type
                                            && hs.ID >= start
                                            && hs.ID <= (start+length)
										   join sub in _context.Suburb on
                                           hs.SASuburbID equals sub.ID
                                           where hs.SASuburbID == sub.ID
                                           join st in _context.State on
                                           sub.StateID equals st.ID
                                           where sub.StateID == st.ID
                                           join ss in _context.CurrentStatus on
                                           hs.SREStatusID equals ss.ID
                                           where hs.SREStatusID == ss.ID
                                           join ga in _context.GeoAccuracy on
                                           hs.GeoAccuracyID equals ga.ID into gaGroup
                                           from ga in gaGroup.DefaultIfEmpty()
                                           join tk in _context.Task on
                                           hs.ID equals tk.VenueID into tkGroup
                                           from tk in tkGroup.DefaultIfEmpty()
                                           join user in _userManager.Users on
                                           tk.AssignToID equals user.Id into userGroup
                                           from user in userGroup.DefaultIfEmpty()
                                           where search == null || (
                                            hs.Nm.ToLower().Contains(search.ToLower()) ||
                                            sub.Nm.ToLower().Contains(search.ToLower()) ||
                                            st.Nm.ToLower().Contains(search.ToLower()) ||
                                            ss.Nm.ToLower().Contains(search.ToLower()) ||
                                            (user.FirstName != null && user.FirstName.ToLower().Contains(search.ToLower()))
                                            )
                                           select new HighSchoolVM
                                           {
                                               ID = hs.ID,
                                               Nm = hs.Nm,
                                               Note = hs.Note,
                                               PostalAddress = hs.PostalAddress,
                                               type = hs.type,
                                               Phone1 = hs.Phone1,
                                               Phone2 = hs.Phone2,
                                               email = hs.email,
                                               email2 = hs.email2,
                                               PASuburbID = sub.ID,
                                               PASuburbName = sub.Nm,
                                               SASuburbID = sub.ID,
                                               PostalCode = sub.PostCode,
                                               SASuburbName = sub.Nm,
                                               StreetAddress = hs.StreetAddress,
                                               StateID = st.ID,
                                               StateName = st.StateCode,
                                               SREStatusID = ss.ID,
                                               SREStatusName = ss.Nm,
                                               GeoAccuracyID = ga.ID,
                                               GeoAccuracyName = ga.GoogleMeaning,
                                               NextTaskDoBy = user.FirstName,
                                               TaskSubject = tk.Subject,
                                               Country = hs.Country,
                                               GooglePlusCode = hs.GooglePlusCode,
                                               MapLink = hs.MapLink,
                                               PostCode = hs.PostCode,
                                               PrincipalEmail = hs.PrincipalEmail,
                                               PrincipalPhone = hs.PrincipalPhone,
                                               Days = ConvertDateToDays(tk.StartDate),
                                               EmailFlag = (hs.email != null && hs.email != "") ? "Y" : "N",
                                               LastInfoSent = tk.StartDate.ToString(),
                                               AssociatedPrimarySchool = _context.PrimarySchool.Where(x => x.HighSchoolID == hs.ID).Count().ToString(),
                                               AssociatedChurch = _context.Church.Where(x => x.HighSchoolID == hs.ID).Count().ToString(),
                                           })
                                           .ToList();


                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<HighSchoolVM>>(null);
            }
        }

        private static string ConvertDateToDays(DateTime? d1)
        {
            DateTime d2 = DateTime.Now;
            return Convert.ToInt32((d2 - d1)?.TotalDays).ToString();
        }
        public Task<HighSchoolVM> GetSingleHighSchoolWithSearch(string id)
        {

            try
            {
                //Check collection is not empty before using the First method.
                if (_context.HighSchool.Any(a => a.ID.ToString() == id))
                {
                    HighSchool mdoel = _context.HighSchool.First(a => a.ID.ToString() == id);
                    HighSchoolVM data = _mapper.Map<HighSchoolVM>(mdoel);
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
