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
    public class DBChurchHandler : IChurch
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBChurchHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditChurch(ChurchVM model, string id = "")
        {

            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<Church>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.Church.AddAsync(entity);
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
                    Church entity = _mapper.Map<Church>(model);
                    Church updatedRecord = await _context.Church.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.YPNum = entity.YPNum;
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
                        updatedRecord.Pastor = entity.Pastor;
                        updatedRecord.HighSchoolID = entity.HighSchoolID;
                        updatedRecord.Participate = entity.Participate;
                        updatedRecord.Note = entity.Note;
                        updatedRecord.MapLink = entity.MapLink;
                        updatedRecord.WebSite = entity.WebSite;
                        updatedRecord.GeoStatusID = entity.GeoStatusID;
                        updatedRecord.GeoAccuracyID = entity.GeoAccuracyID;
                        updatedRecord.Lat = entity.Lat;
                        updatedRecord.Lng = entity.Lng;
                        updatedRecord.LatLongSetByUser = entity.LatLongSetByUser;
                        updatedRecord.WantsNewsletter = entity.WantsNewsletter;
                        updatedRecord.MinisterFraternalID = entity.MinisterFraternalID;
                        updatedRecord.LockAreaID = entity.LockAreaID;
                        updatedRecord.SREBoardID = entity.SREBoardID;
                        updatedRecord.SRECoordinatorID = entity.SRECoordinatorID;
                        updatedRecord.Attendance = entity.Attendance;
                        updatedRecord.SupporterNumber = entity.SupporterNumber;
                        updatedRecord.SuburbID = entity.SuburbID;
                        updatedRecord.Postalcode = entity.Postalcode;
                        updatedRecord.Donation = entity.Donation;
                        updatedRecord.Country = entity.Country;
                        updatedRecord.PastorEmail = entity.PastorEmail;
                        updatedRecord.PastorPhone = entity.PastorPhone;
                        updatedRecord.GooglePlusCode = entity.GooglePlusCode;
                        updatedRecord.externalContactUpdated = entity.externalContactUpdated;
                        updatedRecord.externalContactUpdated2 = entity.externalContactUpdated2;
                        updatedRecord.lastUpdated = entity.lastUpdated;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.Church.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteChurch(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.Church.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<ChurchVM>> GetAllChurch()
        {
            try
            {
                // Retrieve list from the database
                List<ChurchVM> list = (from main in _context.Church
                                       join sub in _context.Suburb on
                                       main.SASuburbID equals sub.ID
                                       where main.SASuburbID == sub.ID
                                       join st in _context.State on
                                       sub.StateID equals st.ID
                                       where sub.StateID == st.ID
                                       join ga in _context.GeoAccuracy on
                                       main.GeoAccuracyID equals ga.ID into gaGroup
                                       from ga in gaGroup.DefaultIfEmpty()
                                       join tk in _context.Task on
                                       main.ID equals tk.VenueID into tkGroup
                                       from tk in tkGroup.DefaultIfEmpty()
                                       join user in _userManager.Users on
                                       tk.AssignToID equals user.Id into userGroup
                                       from user in userGroup.DefaultIfEmpty()
                                       select new ChurchVM
                                       {
                                           ID = main.ID,
                                           YPNum = main.YPNum,
                                           Nm = main.Nm,
                                           StreetAddress = main.StreetAddress,
                                           SASuburbID = main.SASuburbID,
                                           PASameAsSA = main.PASameAsSA,
                                           PostalAddress = main.PostalAddress,
                                           PASuburbID = main.PASuburbID,
                                           Phone1 = main.Phone1,
                                           Phone2 = main.Phone2,
                                           Fax = main.Fax,
                                           email = main.email,
                                           email2 = main.email2,
                                           Pastor = main.Pastor,
                                           HighSchoolID = main.HighSchoolID,
                                           Participate = main.Participate,
                                           Note = main.Note,
                                           MapLink = main.MapLink,
                                           WebSite = main.WebSite,
                                           GeoStatusID = main.GeoStatusID,
                                           GeoAccuracyID = main.GeoAccuracyID,
                                           Lat = main.Lat,
                                           Lng = main.Lng,
                                           LatLongSetByUser = main.LatLongSetByUser,
                                           WantsNewsletter = main.WantsNewsletter,
                                           MinisterFraternalID = main.MinisterFraternalID,
                                           LockAreaID = main.LockAreaID,
                                           SREBoardID = main.SREBoardID,
                                           SRECoordinatorID = main.SRECoordinatorID,
                                           Attendance = main.Attendance,
                                           SupporterNumber = main.SupporterNumber,
                                           SuburbID = sub.ID,
                                           SuburbName = sub.Nm,
                                           Postalcode = main.Postalcode,
                                           Donation = main.Donation,
                                           externalContactUpdated = main.externalContactUpdated,
                                           externalContactUpdated2 = main.externalContactUpdated2,
                                           lastUpdated = main.lastUpdated,
                                           Country = main.Country,
                                           PastorEmail = main.PastorEmail,
                                           PastorPhone = main.PastorPhone,
                                           NextTaskDoBy = user.FirstName,
                                           TaskSubject = tk.Subject,
                                           GooglePlusCode = main.GooglePlusCode,
                                           PostCode = main.PostCode,
                                           Days = ConvertDateToDays(tk.StartDate),
                                           EmailFlag = (main.email != null && main.email != "") ? "Y" : "N",
                                           LastInfoSent = tk.StartDate.ToString(),
                                           AssociatedHighSchool = _context.HighSchool.Where(x => x.ID == main.ID).Count().ToString(),
                                       }).ToList();

                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<ChurchVM>>(null);
            }
        }

        private static string ConvertDateToDays(DateTime? d1)
        {
            DateTime d2 = DateTime.Now;
            return Convert.ToInt32((d2 - d1)?.TotalDays).ToString();
        }
        public Task<List<ChurchVM>> GetAllChurchsWithHighSchool(string hsID)
        {
            int hsid = Convert.ToInt32(hsID);
            try
            {
                // Retrieve list from the database
                List<ChurchVM> list = (from chur in _context.Church
                                       join hs in _context.HighSchool on chur.HighSchoolID equals hs.ID
                                       where chur.HighSchoolID == hsid
                                       select new ChurchVM
                                       {
                                           ID = chur.ID,
                                           Nm = chur.Nm,
                                           Note = chur.Note,
                                       }).ToList();
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<ChurchVM>>(null);
            }
        }

        public Task<ChurchVM> GetSingleChurchWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.Church.Any(a => a.ID.ToString() == id))
                {
                    Church mdoel = _context.Church.First(a => a.ID.ToString() == id);
                    ChurchVM data = _mapper.Map<ChurchVM>(mdoel);
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
