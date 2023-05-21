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
    public class DBMinisterFraternalHandler : IMinisterFraternal
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBMinisterFraternalHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditMinisterFraternal(MinisterFraternalVM model, string id = "")
        {
            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<MinisterFraternal>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.MinisterFraternal.AddAsync(entity);
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
                    MinisterFraternal entity = _mapper.Map<MinisterFraternal>(model);
                    MinisterFraternal updatedRecord = await _context.MinisterFraternal.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.Nm = entity.Nm;
                        updatedRecord.ChurchID = entity.ChurchID;
                        updatedRecord.Note = entity.Note;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.MinisterFraternal.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteMinisterFraternal(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.MinisterFraternal.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<MinisterFraternalVM>> GetAllMinisterFraternal()
        {
            try
            {
                // Retrieve list from the database                
                List<MinisterFraternalVM> list = (from mf in _context.MinisterFraternal
                                                  join ch in _context.Church on
                                                  mf.ChurchID equals ch.ID
                                                  where mf.ChurchID == ch.ID
                                                  select new MinisterFraternalVM
                                                  {
                                                      ID = mf.ID,
                                                      Nm = mf.Nm,
                                                      Note = mf.Note,
                                                      ChurchID = ch.ID,
                                                      ChurchName = ch.Nm,
                                                  }).ToList();
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<MinisterFraternalVM>>(null);
            }
        }

        public Task<MinisterFraternalVM> GetSingleMinisterFraternalWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.MinisterFraternal.Any(a => a.ID.ToString() == id))
                {
                    MinisterFraternal mdoel = _context.MinisterFraternal.First(a => a.ID.ToString() == id);
                    MinisterFraternalVM data = _mapper.Map<MinisterFraternalVM>(mdoel);
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
