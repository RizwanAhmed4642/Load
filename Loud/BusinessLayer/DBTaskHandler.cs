using SAS.Data;
using SAS.Models;
using SAS.Models.ViewModels.GeneralViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SAS.Interfaces;
using SAS.Models.ViewModels.SASViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SAS.BusinessLayer
{
    public class DBTaskHandler : ITask
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBTaskHandler(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditTask(TaskVM model, string id = "")
        {

            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<SAS.Models.Task>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.Task.AddAsync(entity);
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
                    SAS.Models.Task entity = _mapper.Map<SAS.Models.Task>(model);
                    SAS.Models.Task updatedRecord = await _context.Task.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.TaskTypeID = entity.TaskTypeID;
                        updatedRecord.Subject = entity.Subject;
                        updatedRecord.TripID = entity.TripID;
                        updatedRecord.StartDate = entity.StartDate;
                        updatedRecord.DoByDate = entity.DoByDate;
                        updatedRecord.CompletedDate = entity.CompletedDate;
                        updatedRecord.VenueTypeID = entity.VenueTypeID;
                        updatedRecord.VenueID = entity.VenueID;
                        updatedRecord.AssignToID = entity.AssignToID;
                        updatedRecord.Note = entity.Note;
                        updatedRecord.Complete = entity.Complete;
                        updatedRecord.ItemListPos = entity.ItemListPos;
                        updatedRecord.ResponseRecieved = entity.ResponseRecieved;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.Task.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteTask(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.Task.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return System.Threading.Tasks.Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return System.Threading.Tasks.Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<TaskVM>> GetAllTask()
        {
            try
            {
                // Retrieve list from the database
                List<TaskVM> list = (from t in _context.Task
                                     join tt in _context.TaskType on
                                     t.TaskTypeID equals tt.ID
                                     where t.TaskTypeID == tt.ID
                                     join trip in _context.Trip on
                                     t.TripID equals trip.ID
                                     where t.TripID == trip.ID
                                     join user in _userManager.Users on
                                     t.AssignToID equals user.Id
                                     where t.AssignToID == user.Id
                                     select new TaskVM
                                     {
                                         ID = t.ID,
                                         TaskTypeID = tt.ID,
                                         TaskTypeName = tt.Nm,
                                         Subject = t.Subject,
                                         TripID = trip.ID,
                                         TripName = trip.Subject,
                                         StartDate = t.StartDate,
                                         DoByDate = t.DoByDate,
                                         CompletedDate = t.CompletedDate,
                                         VenueTypeID = t.VenueTypeID,
                                         VenueID = t.VenueID,
                                         Note = t.Note,
                                         Complete = t.Complete,
                                         ItemListPos = t.ItemListPos,
                                         ResponseRecieved = t.ResponseRecieved,
                                         AssignToID = user.Id,
                                         AssignToName = user.FirstName,
                                     }).ToList();

                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return System.Threading.Tasks.Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return System.Threading.Tasks.Task.FromResult<List<TaskVM>>(null);
            }
        }

        public Task<List<TaskVM>> GetAllTasksWithHighSchool(string hsID, string venueTypeID)
        {
            int hsid = Convert.ToInt32(hsID);
            try
            {
                // Retrieve list from the database
                List<TaskVM> list = (from t in _context.Task
                                     join hs in _context.HighSchool on t.VenueID equals hs.ID
                                     where t.VenueID == hsid
                                     join tt in _context.TaskType on t.TaskTypeID equals tt.ID
                                     where t.TaskTypeID == tt.ID
                                     select new TaskVM
                                     {
                                         ID = t.ID,
                                         TaskTypeID = tt.ID,
                                         TaskTypeName = tt.Nm,
                                         Subject = t.Subject,
                                         StartDate = t.StartDate,
                                         DoByDate = t.DoByDate,
                                         CompletedDate = t.CompletedDate,
                                         VenueTypeID = t.VenueTypeID,
                                         VenueID = t.VenueID,
                                         Note = t.Note,
                                         Complete = t.Complete,
                                         ItemListPos = t.ItemListPos,
                                         ResponseRecieved = t.ResponseRecieved,
                                     }).ToList();



                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return System.Threading.Tasks.Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return System.Threading.Tasks.Task.FromResult<List<TaskVM>>(null);
            }
        }

        public Task<List<TaskVM>> GetAllTasksWithPrimarySchool(string psID, string venueTypeID)
        {
            int hsid = Convert.ToInt32(psID);
            try
            {
                // Retrieve list from the database
                List<TaskVM> list = (from t in _context.Task
                                     join ps in _context.PrimarySchool on t.VenueID equals ps.ID
                                     where t.VenueID == hsid
                                     join tt in _context.TaskType on t.TaskTypeID equals tt.ID
                                     where t.TaskTypeID == tt.ID
                                     select new TaskVM
                                     {
                                         ID = t.ID,
                                         TaskTypeID = tt.ID,
                                         TaskTypeName = tt.Nm,
                                         Subject = t.Subject,
                                         StartDate = t.StartDate,
                                         DoByDate = t.DoByDate,
                                         CompletedDate = t.CompletedDate,
                                         VenueTypeID = t.VenueTypeID,
                                         VenueID = t.VenueID,
                                         Note = t.Note,
                                         Complete = t.Complete,
                                         ItemListPos = t.ItemListPos,
                                         ResponseRecieved = t.ResponseRecieved,
                                     }).ToList();



                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return System.Threading.Tasks.Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return System.Threading.Tasks.Task.FromResult<List<TaskVM>>(null);
            }
        }

        public Task<List<TaskVM>> GetAllTasksWithChurch(string cID, string venueTypeID)
        {
            int cid = Convert.ToInt32(cID);
            try
            {
                // Retrieve list from the database
                List<TaskVM> list = (from t in _context.Task
                                     join main in _context.Church on t.VenueID equals main.ID
                                     where t.VenueID == cid
                                     join tt in _context.TaskType on t.TaskTypeID equals tt.ID
                                     where t.TaskTypeID == tt.ID
                                     select new TaskVM
                                     {
                                         ID = t.ID,
                                         TaskTypeID = tt.ID,
                                         TaskTypeName = tt.Nm,
                                         Subject = t.Subject,
                                         StartDate = t.StartDate,
                                         DoByDate = t.DoByDate,
                                         CompletedDate = t.CompletedDate,
                                         VenueTypeID = t.VenueTypeID,
                                         VenueID = t.VenueID,
                                         Note = t.Note,
                                         Complete = t.Complete,
                                         ItemListPos = t.ItemListPos,
                                         ResponseRecieved = t.ResponseRecieved,
                                     }).ToList();



                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return System.Threading.Tasks.Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return System.Threading.Tasks.Task.FromResult<List<TaskVM>>(null);
            }
        }
        public Task<TaskVM> GetSingleTaskWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.Task.Any(a => a.ID.ToString() == id))
                {
                    SAS.Models.Task mdoel = _context.Task.First(a => a.ID.ToString() == id);
                    TaskVM data = _mapper.Map<TaskVM>(mdoel);
                    return System.Threading.Tasks.Task.FromResult(data);
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
