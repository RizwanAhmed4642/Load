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
    public class DBCurrentStatusHandler : ICurrentStatus
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBCurrentStatusHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditCurrentStatus(CurrentStatusVM model, string id = "")
        {

            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<CurrentStatus>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.CurrentStatus.AddAsync(entity);
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
                    CurrentStatus entity = _mapper.Map<CurrentStatus>(model);
                    CurrentStatus updatedRecord = await _context.CurrentStatus.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.Nm = entity.Nm;
                        updatedRecord.Opportunity = entity.Opportunity;
                        updatedRecord.HighSchoolIcon = entity.HighSchoolIcon;
                        updatedRecord.PrimSchoolIcon = entity.PrimSchoolIcon;
                        updatedRecord.PrivateHighIcon = entity.PrivateHighIcon;
                        updatedRecord.PrivatePrimaryIcon = entity.PrivatePrimaryIcon;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.CurrentStatus.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteCurrentStatus(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.CurrentStatus.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<CurrentStatusVM>> GetAllCurrentStatus()
        {
            try
            {
                // Retrieve list from the database
                List<CurrentStatusVM> list = (from cs in _context.CurrentStatus
                                         select new CurrentStatusVM
                                         {
                                             ID = cs.ID,
                                             Nm = cs.Nm,
                                             Opportunity = cs.Opportunity,
                                             HighSchoolIcon = cs.HighSchoolIcon,
                                             PrimSchoolIcon = cs.PrimSchoolIcon,
                                             PrivateHighIcon = cs.PrivateHighIcon,
                                             PrivatePrimaryIcon = cs.PrivatePrimaryIcon,
                                         }).ToList();

                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<CurrentStatusVM>>(null);
            }
        }

        public Task<CurrentStatusVM> GetSingleCurrentStatusWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.CurrentStatus.Any(a => a.ID.ToString() == id))
                {
                    CurrentStatus mdoel = _context.CurrentStatus.First(a => a.ID.ToString() == id);
                    CurrentStatusVM data = _mapper.Map<CurrentStatusVM>(mdoel);
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
