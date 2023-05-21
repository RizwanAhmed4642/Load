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

namespace SAS.BusinessLayer
{
    public class DBChaplainTaskTypeHandler : IChaplainTaskType
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBChaplainTaskTypeHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditChaplainTaskType(ChaplainTaskTypeVM model, string id = "")
        {
            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<ChaplainTaskType>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.ChaplainTaskType.AddAsync(entity);
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
                    ChaplainTaskType entity = _mapper.Map<ChaplainTaskType>(model);
                    ChaplainTaskType updatedRecord = await _context.ChaplainTaskType.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.Nm = entity.Nm;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.ChaplainTaskType.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteChaplainTaskType(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.ChaplainTaskType.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<ChaplainTaskType>> GetAllChaplainTaskType()
        {
            try
            {
                // Retrieve list from the database
                List<ChaplainTaskType> list = _context.ChaplainTaskType.ToList();
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<ChaplainTaskType>>(null);
            }
        }

        public Task<ChaplainTaskTypeVM> GetSingleChaplainTaskTypeWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.ChaplainTaskType.Any(a => a.ID.ToString() == id))
                {
                    ChaplainTaskType mdoel = _context.ChaplainTaskType.First(a => a.ID.ToString() == id);
                    ChaplainTaskTypeVM data = _mapper.Map<ChaplainTaskTypeVM>(mdoel);
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
