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
    public class DBSRECoordinatorHandler : ISRECoordinator
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBSRECoordinatorHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditSRECoordinator(SRECoordinatorVM model, string id = "")
        {

            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<SRECoordinator>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.SRECoordinator.AddAsync(entity);
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
                    SRECoordinator entity = _mapper.Map<SRECoordinator>(model);
                    SRECoordinator updatedRecord = await _context.SRECoordinator.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.Note = entity.Note;
                        updatedRecord.Nm = entity.Nm;
                        updatedRecord.FirstName = entity.FirstName;
                        updatedRecord.LastName = entity.LastName;
                        updatedRecord.PostalAddress = entity.PostalAddress;
                        updatedRecord.PASuburbID = entity.PASuburbID;
                        updatedRecord.SRECoordinatorRepID = entity.SRECoordinatorRepID;
                        updatedRecord.Phone1 = entity.Phone1;
                        updatedRecord.Phone2 = entity.Phone2;
                        updatedRecord.email = entity.email;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.SRECoordinator.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteSRECoordinator(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.SRECoordinator.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<SRECoordinatorVM>> GetAllSRECoordinator()
        {
            try
            {
                // Retrieve list from the database
                List<SRECoordinatorVM> list = (from sr in _context.SRECoordinator
                                               join su in _context.Suburb on
                                               sr.PASuburbID equals su.ID
                                               where sr.PASuburbID == su.ID
                                               join srp in _context.SRERep on
                                               sr.SRECoordinatorRepID equals srp.ID
                                               where sr.SRECoordinatorRepID == srp.ID
                                               select new SRECoordinatorVM
                                               {
                                                   ID = sr.ID,
                                                   Note = sr.Note,
                                                   Nm = sr.Nm,
                                                   FirstName = sr.FirstName,
                                                   LastName = sr.LastName,
                                                   PostalAddress = sr.PostalAddress,
                                                   PASuburbID = sr.PASuburbID,
                                                   SRECoordinatorRepID = sr.SRECoordinatorRepID,
                                                   Phone1 = sr.Phone1,
                                                   Phone2 = sr.Phone2,
                                                   email = sr.email,
                                                   PASuburbName = su.Nm,
                                                   SRECoordinatorRepName = srp.FirstName
                                               }).ToList();

                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<SRECoordinatorVM>>(null);
            }
        }

        public Task<SRECoordinatorVM> GetSingleSRECoordinatorWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.SRECoordinator.Any(a => a.ID.ToString() == id))
                {
                    SRECoordinator mdoel = _context.SRECoordinator.First(a => a.ID.ToString() == id);
                    SRECoordinatorVM data = _mapper.Map<SRECoordinatorVM>(mdoel);
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
