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

    public class DBSRERepHandler : ISRERep
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBSRERepHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditSRERep(SRERepVM model, string id = "")
        {

            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<SRERep>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.SRERep.AddAsync(entity);
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
                    SRERep entity = _mapper.Map<SRERep>(model);
                    SRERep updatedRecord = await _context.SRERep.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.Note = entity.Note;
                        updatedRecord.FirstName = entity.FirstName;
                        updatedRecord.LastName = entity.LastName;
                        updatedRecord.StreetAddress = entity.StreetAddress;
                        updatedRecord.SASuburbID = entity.SASuburbID;
                        updatedRecord.PASameAsSA = entity.PASameAsSA;
                        updatedRecord.PostalAddress = entity.PostalAddress;
                        updatedRecord.PASuburbID = entity.PASuburbID;
                        updatedRecord.Fax = entity.Fax;
                        updatedRecord.Phone1 = entity.Phone1;
                        updatedRecord.Phone2 = entity.Phone2;
                        updatedRecord.email = entity.email;
                        updatedRecord.Current = entity.Current;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.SRERep.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteSRERep(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.SRERep.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<SRERepVM>> GetAllSRERep()
        {
            try
            {
                // Retrieve list from the database
                List<SRERepVM> list = (from sr in _context.SRERep
                                         join su in _context.Suburb on
                                         sr.PASuburbID equals su.ID
                                         where sr.PASuburbID == su.ID
                                         select new SRERepVM
                                         {
                                             ID = sr.ID,
                                             Note = sr.Note,
                                             FirstName = sr.FirstName,
                                             LastName = sr.LastName,
                                             StreetAddress = sr.StreetAddress,
                                             SASuburbID = sr.SASuburbID,
                                             PASameAsSA = sr.PASameAsSA,
                                             PostalAddress = sr.PostalAddress,
                                             PASuburbID = sr.PASuburbID,
                                             Fax = sr.Fax,
                                             Phone1 = sr.Phone1,
                                             Phone2 = sr.Phone2,
                                             email = sr.email,
                                             Current = sr.Current,
                                             SASuburbName = su.Nm,
                                             PASuburbName = su.Nm
                                         }).ToList();

                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<SRERepVM>>(null);
            }
        }

        public Task<SRERepVM> GetSingleSRERepWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.SRERep.Any(a => a.ID.ToString() == id))
                {
                    SRERep mdoel = _context.SRERep.First(a => a.ID.ToString() == id);
                    SRERepVM data = _mapper.Map<SRERepVM>(mdoel);
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
