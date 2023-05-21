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
using AutoMapper.Internal;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace SAS.BusinessLayer
{
    public class DBUserAreasHandler : IUserAreas
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBUserAreasHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditUserArea(UserAreasVM model, string id = "")
        {
            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<UserAreas>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.UserAreas.AddAsync(entity);
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
                    UserAreas entity = _mapper.Map<UserAreas>(model);
                    UserAreas updatedRecord = await _context.UserAreas.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.AreaID = entity.AreaID;
                        updatedRecord.UserID = entity.UserID;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.UserAreas.Update(updatedRecord);
                        await _context.SaveChangesAsync();
                    }

                    return new ErrorVM { Status = true, ErrorCode = "200", Message = "Saved Successfully" };
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
        public Task<ErrorVM> DeleteUserArea(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.UserAreas.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                //Cannot implicitly convert type 'AdminLTE.Models.ViewModels.GeneralViewModels.ErrorVM' to 'System.Threading.Tasks.Task<AdminLTE.Models.ViewModels.GeneralViewModels.ErrorVM>'
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<ErrorVM> DeleteUserAreaWithUserID(string UserID)
        {
            try
            {
                if (UserID != "")
                {
                    _context.UserAreas.RemoveRange(_context.UserAreas.Where(a => a.UserID == UserID));
                    _context.SaveChanges();
                }
                //Cannot implicitly convert type 'AdminLTE.Models.ViewModels.GeneralViewModels.ErrorVM' to 'System.Threading.Tasks.Task<AdminLTE.Models.ViewModels.GeneralViewModels.ErrorVM>'
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<UserAreas>> GetAllUserArea()
        {
            try
            {
                // Retrieve areas from the database
                List<UserAreas> areas = _context.UserAreas.ToList();
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return Task.FromResult(areas);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return Task.FromResult<List<UserAreas>>(null);
            }
        }

        public Task<List<UserAreasVM>> GetAllUserAreasWithUserID(string UserID)
        {
            try
            {
                List<UserAreasVM> data = _context.Area.Join(_context.UserAreas,
                                                a => a.ID,
                                                ua => ua.AreaID,
                                                (a, ua) => new { Area = a, UserArea = ua })
                                                .Where(au => au.UserArea.UserID == UserID)
                                                .Select(au => new UserAreasVM
                                                {
                                                    ID = au.Area.ID,
                                                    Nm = au.Area.Nm,
                                                    StartLat = au.Area.StartLat,
                                                    StartLng = au.Area.StartLng,
                                                    EndLat = au.Area.EndLat,
                                                    EndLng = au.Area.EndLng,
                                                    SASChurchPartnerID = au.Area.SASChurchPartnerID,
                                                    Colour = au.Area.Colour,
                                                    UserAreaID = au.UserArea.ID
                                                }).ToList();

                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return Task.FromResult(data);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return Task.FromResult<List<UserAreasVM>>(null);
            }
        }

        public async Task<List<GoogleMapPinsVM>> GetAllUserAreasAndVenus(int areaID = 0)
        {
            try
            {
                List<GoogleMapPinsVM> HSchools = await GetAllUserAreasAndHighSchoolVenus(areaID);
                List<GoogleMapPinsVM> PSchools = await GetAllUserAreasAndPrimarySchoolVenus(areaID);
                List<GoogleMapPinsVM> churches = await GetAllUserAreasAndChurchVenus(areaID);

                List<GoogleMapPinsVM> dataPins = HSchools.Concat(PSchools).Concat(churches).ToList();

                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return await Task.FromResult(dataPins);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return await Task.FromResult<List<GoogleMapPinsVM>>(null);
            }
        }

        public async Task<List<GoogleMapPinsVM>> GetAllUserAreasAndVenusWithUserID(string UserID, int areaID = 0)
        {
            try
            {
                List<GoogleMapPinsVM> HSchools = await GetAllUserAreasAndHighSchoolVenusWithUserID(UserID, areaID);
                List<GoogleMapPinsVM> PSchools = await GetAllUserAreasAndPrimarySchoolVenusWithUserID(UserID, areaID);
                List<GoogleMapPinsVM> churches = await GetAllUserAreasAndChurchVenusWithUserID(UserID, areaID);

                List<GoogleMapPinsVM> dataPins = HSchools.Concat(PSchools).Concat(churches).ToList();

                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return await Task.FromResult(dataPins);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return await Task.FromResult<List<GoogleMapPinsVM>>(null);
            }
        }

        public Task<List<GoogleMapPinsVM>> GetAllUserAreasAndHighSchoolVenus(int areaID=0)
        {
            try
            {
                var dataPins = (from ua in _context.UserAreas
								join main in _context.HighSchool on ua.AreaID equals main.AreaID
								join sub in _context.Suburb on main.SASuburbID equals sub.ID
                                join state in _context.State on sub.StateID equals state.ID
								where (areaID == 0 || main.AreaID == areaID)
								select new GoogleMapPinsVM
                                {
                                    id = main.ID,
                                    nm = main.Nm,
                                    lat = (float?)main.Lat,
                                    lng = (float?)main.Lng,
                                    venueName = "High School",
                                    type = main.type,
                                    StreetAddress = main.StreetAddress,
                                    Phone1 = main.Phone1,
                                    Phone2 = main.Phone2,
                                    email = main.email,
                                    email2 = main.email2,
                                    AreaID = main.AreaID,
                                    SREStatusID=main.SREStatusID,
                                    TypeAliases = "HS",
                                    SuburbName = sub.Nm,
                                    StateName = state.StateCode,
                                }).ToList();

                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return Task.FromResult(dataPins);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return Task.FromResult<List<GoogleMapPinsVM>>(null);
            }
        }

        public Task<List<GoogleMapPinsVM>> GetAllUserAreasAndHighSchoolVenusWithUserID(string UserID, int areaID = 0)
        {
            try
            {
                var dataPins = (from ua in _context.UserAreas
                                where ua.UserID == UserID
                                join main in _context.HighSchool on ua.AreaID equals main.AreaID
                                join sub in _context.Suburb on main.SASuburbID equals sub.ID
                                join state in _context.State on sub.StateID equals state.ID
				where (areaID == 0 || main.AreaID == areaID)
								select new GoogleMapPinsVM
                                {
                                    id = main.ID,
                                    nm = main.Nm,
                                    lat = (float?)main.Lat,
                                    lng = (float?)main.Lng,
                                    venueName = "High School",
                                    type = main.type,
                                    StreetAddress = main.StreetAddress,
                                    Phone1 = main.Phone1,
                                    Phone2 = main.Phone2,
                                    email = main.email,
                                    email2 = main.email2,
									AreaID = main.AreaID,
									SREStatusID = main.SREStatusID,
									TypeAliases = "HS",
                                    SuburbName = sub.Nm,
                                    StateName = state.StateCode,
                                }).ToList();
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return Task.FromResult(dataPins);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return Task.FromResult<List<GoogleMapPinsVM>>(null);
            }
        }

        public Task<List<GoogleMapPinsVM>> GetAllUserAreasAndPrimarySchoolVenus(int areaID = 0)
        {
            try
            {
                var dataPins = (from ua in _context.UserAreas
                                join main in _context.PrimarySchool on ua.AreaID equals main.HighSchoolID
                                join sub in _context.Suburb on main.SASuburbID equals sub.ID
                                join state in _context.State on sub.StateID equals state.ID
								where (areaID == 0 || main.AreaID == areaID)
								select new GoogleMapPinsVM
                                {
                                    id = main.ID,
                                    nm = main.Nm,
                                    lat = (float?)main.Lat,
                                    lng = (float?)main.Lng,
                                    venueName = "Primary School",
                                    type = main.type,
                                    StreetAddress = main.StreetAddress,
                                    Phone1 = main.Phone1,
                                    Phone2 = main.Phone2,
                                    email = main.email,
                                    email2 = main.email2,
									AreaID = main.AreaID,
									SREStatusID = main.SREStatusID,
									TypeAliases = "PS",
                                    SuburbName = sub.Nm,
                                    StateName = state.StateCode,
                                }).ToList();

                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return Task.FromResult(dataPins);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return Task.FromResult<List<GoogleMapPinsVM>>(null);
            }
        }

        public Task<List<GoogleMapPinsVM>> GetAllUserAreasAndPrimarySchoolVenusWithUserID(string UserID, int areaID = 0)
        {
            try
            {
                var dataPins = (from ua in _context.UserAreas
                                where ua.UserID == UserID
                                join main in _context.PrimarySchool on ua.AreaID equals main.HighSchoolID
                                join sub in _context.Suburb on main.SASuburbID equals sub.ID
                                join state in _context.State on sub.StateID equals state.ID
								where (areaID == 0 || main.AreaID == areaID)
								select new GoogleMapPinsVM
                                {
                                    id = main.ID,
                                    nm = main.Nm,
                                    lat = (float?)main.Lat,
                                    lng = (float?)main.Lng,
                                    venueName = "Primary School",
                                    type = main.type,
                                    StreetAddress = main.StreetAddress,
                                    Phone1 = main.Phone1,
                                    Phone2 = main.Phone2,
                                    email = main.email,
                                    email2 = main.email2,
									AreaID = main.AreaID,
									SREStatusID = main.SREStatusID,
									TypeAliases = "PS",
                                    SuburbName = sub.Nm,
                                    StateName = state.StateCode,
                                }).ToList();


                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return Task.FromResult(dataPins);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return Task.FromResult<List<GoogleMapPinsVM>>(null);
            }
        }

        public Task<List<GoogleMapPinsVM>> GetAllUserAreasAndChurchVenus(int areaID = 0)
        {
            try
            {
                var dataPins = (from ua in _context.UserAreas
                                join main in _context.Church on ua.AreaID equals main.HighSchoolID
                                join sub in _context.Suburb on main.SASuburbID equals sub.ID
                                join state in _context.State on sub.StateID equals state.ID
								where (areaID == 0 || main.AreaID == areaID)
								select new GoogleMapPinsVM
                                {
                                    id = main.ID,
                                    nm = main.Nm,
                                    lat = (float?)main.Lat,
                                    lng = (float?)main.Lng,
                                    venueName = "Church",
                                    type = "Church",
                                    StreetAddress = main.StreetAddress,
                                    Phone1 = main.Phone1,
                                    Phone2 = main.Phone2,
                                    email = main.email,
                                    email2 = main.email2,
									AreaID = main.AreaID,
									Participate = main.Participate,
									TypeAliases = "C",
                                    SuburbName = sub.Nm,
                                    StateName = state.StateCode,
                                }).ToList();

                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return Task.FromResult(dataPins);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return Task.FromResult<List<GoogleMapPinsVM>>(null);
            }
        }

        public Task<List<GoogleMapPinsVM>> GetAllUserAreasAndChurchVenusWithUserID(string UserID, int areaID = 0)
        {
            try
            {
                var dataPins = (from ua in _context.UserAreas
                                where ua.UserID == UserID
                                join main in _context.Church on ua.AreaID equals main.HighSchoolID
                                join sub in _context.Suburb on main.SASuburbID equals sub.ID
                                join state in _context.State on sub.StateID equals state.ID
								where (areaID == 0 || main.AreaID == areaID)
								select new GoogleMapPinsVM
                                {
                                    id = main.ID,
                                    nm = main.Nm,
                                    lat = (float?)main.Lat,
                                    lng = (float?)main.Lng,
                                    venueName = "Church",
                                    type = "Church",
                                    StreetAddress = main.StreetAddress,
                                    Phone1 = main.Phone1,
                                    Phone2 = main.Phone2,
                                    email = main.email,
                                    email2 = main.email2,
									AreaID = main.AreaID,
									Participate = main.Participate,
									TypeAliases = "C",
                                    SuburbName = sub.Nm,
                                    StateName = state.StateCode,
                                }).ToList();

                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return Task.FromResult(dataPins);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of areas.
                return Task.FromResult<List<GoogleMapPinsVM>>(null);
            }
        }

        public Task<UserAreas> GetSingleUserAreaWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.UserAreas.Any(a => a.ID.ToString() == id))
                {
                    return Task.FromResult(_context.UserAreas.First(a => a.ID.ToString() == id));
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
