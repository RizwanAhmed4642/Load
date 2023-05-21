﻿using SAS.Data;
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
    public class DBSRECoordinatorTaskTypeHandler : ISRECoordinatorTaskType
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBSRECoordinatorTaskTypeHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditSRECoordinatorTaskType(SRECoordinatorTaskTypeVM model, string id = "")
        {
            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<SRECoordinatorTaskType>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.SRECoordinatorTaskType.AddAsync(entity);
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
                    SRECoordinatorTaskType entity = _mapper.Map<SRECoordinatorTaskType>(model);
                    SRECoordinatorTaskType updatedRecord = await _context.SRECoordinatorTaskType.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.Nm = entity.Nm;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.SRECoordinatorTaskType.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteSRECoordinatorTaskType(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.SRECoordinatorTaskType.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<SRECoordinatorTaskType>> GetAllSRECoordinatorTaskType()
        {
            try
            {
                // Retrieve list from the database
                List<SRECoordinatorTaskType> list = _context.SRECoordinatorTaskType.ToList();
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<SRECoordinatorTaskType>>(null);
            }
        }

        public Task<SRECoordinatorTaskTypeVM> GetSingleSRECoordinatorTaskTypeWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.SRECoordinatorTaskType.Any(a => a.ID.ToString() == id))
                {
                    SRECoordinatorTaskType mdoel = _context.SRECoordinatorTaskType.First(a => a.ID.ToString() == id);
                    SRECoordinatorTaskTypeVM data = _mapper.Map<SRECoordinatorTaskTypeVM>(mdoel);
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
