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
    public class DBMinisterFraternalTaskHandler : IMinisterFraternalTask
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBMinisterFraternalTaskHandler(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditMinisterFraternalTask(MinisterFraternalTaskVM model, string id = "")
        {

            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<MinisterFraternalTask>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.MinisterFraternalTask.AddAsync(entity);
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
                    MinisterFraternalTask entity = _mapper.Map<MinisterFraternalTask>(model);
                    MinisterFraternalTask updatedRecord = await _context.MinisterFraternalTask.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.MinisterFraternalID = entity.MinisterFraternalID;
                        updatedRecord.MinisterFraternalTaskTypeID = entity.MinisterFraternalTaskTypeID;
                        updatedRecord.Subject = entity.Subject;
                        updatedRecord.StartDate = entity.StartDate;
                        updatedRecord.AssignToID = entity.AssignToID;
                        updatedRecord.Note = entity.Note;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.MinisterFraternalTask.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteMinisterFraternalTask(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.MinisterFraternalTask.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<MinisterFraternalTaskVM>> GetAllMinisterFraternalTask()
        {
            try
            {
                // Retrieve list from the database
                List<MinisterFraternalTaskVM> list = (from mft in _context.MinisterFraternalTask
                                             join mf in _context.MinisterFraternal on
                                             mft.MinisterFraternalID equals mf.ID
                                             where mft.MinisterFraternalID == mf.ID
                                             join mftt in _context.MinisterFraternalTaskType on
                                             mft.MinisterFraternalTaskTypeID equals mftt.ID
                                             where mft.MinisterFraternalTaskTypeID == mftt.ID
                                             join user in _userManager.Users on
                                             mft.AssignToID equals user.Id
                                             where mft.AssignToID == user.Id
                                             select new MinisterFraternalTaskVM
                                             {
                                                 ID = mft.ID,
                                                 MinisterFraternalID = mf.ID,
                                                 MinisterFraternalName = mf.Nm,
                                                 MinisterFraternalTaskTypeID = mft.MinisterFraternalTaskTypeID,
                                                 MinisterFraternalTaskTypeName = mftt.Nm,
                                                 Subject = mft.Subject,
                                                 StartDate = mft.StartDate,
                                                 AssignToID = mft.AssignToID,
                                                 AssignToName = user.FirstName,
                                                 Note = mft.Note,
                                             }).ToList();

                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<MinisterFraternalTaskVM>>(null);
            }
        }

        public Task<MinisterFraternalTaskVM> GetSingleMinisterFraternalTaskWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.MinisterFraternalTask.Any(a => a.ID.ToString() == id))
                {
                    MinisterFraternalTask mdoel = _context.MinisterFraternalTask.First(a => a.ID.ToString() == id);
                    MinisterFraternalTaskVM data = _mapper.Map<MinisterFraternalTaskVM>(mdoel);
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
