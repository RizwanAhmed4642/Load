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
    public class DBChaplainTaskHandler : IChaplainTask
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBChaplainTaskHandler(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditChaplainTask(ChaplainTaskVM model, string id = "")
        {

            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<ChaplainTask>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.ChaplainTask.AddAsync(entity);
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
                    ChaplainTask entity = _mapper.Map<ChaplainTask>(model);
                    ChaplainTask updatedRecord = await _context.ChaplainTask.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.ChaplainID = entity.ChaplainID;
                        updatedRecord.ChaplainTaskTypeID = entity.ChaplainTaskTypeID;
                        updatedRecord.Subject = entity.Subject;
                        updatedRecord.StartDate = entity.StartDate;
                        updatedRecord.AssignToID = entity.AssignToID;
                        updatedRecord.Note = entity.Note;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.ChaplainTask.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteChaplainTask(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.ChaplainTask.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<ChaplainTaskVM>> GetAllChaplainTask()
        {
            try
            {
                // Retrieve list from the database
                List<ChaplainTaskVM> list = (from ctask in _context.ChaplainTask
                                             join chap in _context.Chaplain on
                                             ctask.ChaplainID equals chap.ID
                                             where ctask.ChaplainID == chap.ID
                                             join cttype in _context.ChaplainTaskType on
                                             ctask.ChaplainTaskTypeID equals cttype.ID
                                             where ctask.ChaplainTaskTypeID == cttype.ID
                                             join user in _userManager.Users on
                                             ctask.AssignToID equals user.Id
                                             where ctask.AssignToID == user.Id
                                             select new ChaplainTaskVM
                                             {
                                                 ID = ctask.ID,
                                                 ChaplainID = ctask.ChaplainID,
                                                 ChaplainName = chap.Nm,
                                                 ChaplainTaskTypeID = ctask.ChaplainTaskTypeID,
                                                 ChaplainTaskTypeName = cttype.Nm,
                                                 Subject = ctask.Subject,
                                                 StartDate = ctask.StartDate,
                                                 AssignToID = ctask.AssignToID,
                                                 AssignToName = user.FirstName,
                                                 Note = ctask.Note,
                                             }).ToList();

                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<ChaplainTaskVM>>(null);
            }
        }

        public Task<ChaplainTaskVM> GetSingleChaplainTaskWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.ChaplainTask.Any(a => a.ID.ToString() == id))
                {
                    ChaplainTask mdoel = _context.ChaplainTask.First(a => a.ID.ToString() == id);
                    ChaplainTaskVM data = _mapper.Map<ChaplainTaskVM>(mdoel);
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
