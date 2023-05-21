using SAS.Data;
using SAS.Interfaces;
using SAS.Models;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace SAS.BusinessLayer
{
    public class DBSRECoordinatorTaskHandler : ISRECoordinatorTask
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBSRECoordinatorTaskHandler(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditSRECoordinatorTask(SRECoordinatorTaskVM model, string id = "")
        {

            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<SRECoordinatorTask>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.SRECoordinatorTask.AddAsync(entity);
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
                    SRECoordinatorTask entity = _mapper.Map<SRECoordinatorTask>(model);
                    SRECoordinatorTask updatedRecord = await _context.SRECoordinatorTask.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.SRECoordinatorID = entity.SRECoordinatorID;
                        updatedRecord.SRECoordinatorTaskTypeID = entity.SRECoordinatorTaskTypeID;
                        updatedRecord.Subject = entity.Subject;
                        updatedRecord.StartDate = entity.StartDate;
                        updatedRecord.AssignToID = entity.AssignToID;
                        updatedRecord.Note = entity.Note;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.SRECoordinatorTask.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteSRECoordinatorTask(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.SRECoordinatorTask.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<SRECoordinatorTaskVM>> GetAllSRECoordinatorTask()
        {
            try
            {
                // Retrieve list from the database
                List<SRECoordinatorTaskVM> list = (from srec in _context.SRECoordinatorTask
                                                   join srectt in _context.SRECoordinatorTaskType on
                                                   srec.SRECoordinatorTaskTypeID equals srectt.ID
                                                   where srec.SRECoordinatorTaskTypeID == srectt.ID
                                                   join srect in _context.SRECoordinator on
                                                   srec.SRECoordinatorID equals srect.ID
                                                   where srec.SRECoordinatorID == srect.ID
                                                   join user in _userManager.Users on
                                                   srec.AssignToID equals user.Id
                                                   where srec.AssignToID == user.Id
                                                   select new SRECoordinatorTaskVM
                                                   {
                                                       ID = srec.ID,
                                                       SRECoordinatorID = srec.SRECoordinatorID,
                                                       SRECoordinatorName = srect.Nm,
                                                       SRECoordinatorTaskTypeID = srec.SRECoordinatorTaskTypeID,
                                                       SRECoordinatorTaskTypeName = srectt.Nm,
                                                       Subject = srec.Subject,
                                                       StartDate = srec.StartDate,
                                                       AssignToID = srec.AssignToID,
                                                       AssignToName = user.FirstName,
                                                       Note = srec.Note,
                                                   }).ToList();

                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<SRECoordinatorTaskVM>>(null);
            }
        }

        public Task<SRECoordinatorTaskVM> GetSingleSRECoordinatorTaskWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.SRECoordinatorTask.Any(a => a.ID.ToString() == id))
                {
                    SRECoordinatorTask mdoel = _context.SRECoordinatorTask.First(a => a.ID.ToString() == id);
                    SRECoordinatorTaskVM data = _mapper.Map<SRECoordinatorTaskVM>(mdoel);
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
