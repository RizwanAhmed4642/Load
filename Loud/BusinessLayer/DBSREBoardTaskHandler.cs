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
    public class DBSREBoardTaskHandler : ISREBoardTask
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBSREBoardTaskHandler(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditSREBoardTask(SREBoardTaskVM model, string id = "")
        {

            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<SREBoardTask>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.SREBoardTask.AddAsync(entity);
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
                    SREBoardTask entity = _mapper.Map<SREBoardTask>(model);
                    SREBoardTask updatedRecord = await _context.SREBoardTask.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.SREBoardID = entity.SREBoardID;
                        updatedRecord.SREBoardTaskTypeID = entity.SREBoardTaskTypeID;
                        updatedRecord.Subject = entity.Subject;
                        updatedRecord.StartDate = entity.StartDate;
                        updatedRecord.AssignToID = entity.AssignToID;
                        updatedRecord.Note = entity.Note;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.SREBoardTask.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteSREBoardTask(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.SREBoardTask.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<SREBoardTaskVM>> GetAllSREBoardTask()
        {
            try
            {
                // Retrieve list from the database
                List<SREBoardTaskVM> list = (from sreb in _context.SREBoardTask
                                             join srecbt in _context.SREBoard on
                                             sreb.SREBoardID equals srecbt.ID
                                             where sreb.SREBoardID == srecbt.ID
                                             join srecbtt in _context.SREBoardTaskType on
                                             sreb.SREBoardTaskTypeID equals srecbtt.ID
                                             where sreb.SREBoardTaskTypeID == srecbtt.ID
                                             join user in _userManager.Users on
                                             sreb.AssignToID equals user.Id
                                             where sreb.AssignToID == user.Id
                                             select new SREBoardTaskVM
                                             {
                                                 ID = sreb.ID,
                                                 SREBoardID = sreb.SREBoardID,
                                                 SREBoardName = srecbt.Nm,
                                                 SREBoardTaskTypeID = sreb.SREBoardTaskTypeID,
                                                 SREBoardTaskTypeName = srecbtt.Nm,
                                                 Subject = sreb.Subject,
                                                 StartDate = sreb.StartDate,
                                                 AssignToID = sreb.AssignToID,
                                                 AssignToName = user.FirstName,
                                                 Note = sreb.Note,
                                             }).ToList();

                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<SREBoardTaskVM>>(null);
            }
        }

        public Task<SREBoardTaskVM> GetSingleSREBoardTaskWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.SREBoardTask.Any(a => a.ID.ToString() == id))
                {
                    SREBoardTask mdoel = _context.SREBoardTask.First(a => a.ID.ToString() == id);
                    SREBoardTaskVM data = _mapper.Map<SREBoardTaskVM>(mdoel);
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
