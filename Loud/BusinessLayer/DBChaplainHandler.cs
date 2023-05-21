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
    public class DBChaplainHandler : IChaplain
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBChaplainHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditChaplain(ChaplainVM model, string id = "")
        {

            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<Chaplain>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.Chaplain.AddAsync(entity);
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
                    Chaplain entity = _mapper.Map<Chaplain>(model);
                    Chaplain updatedRecord = await _context.Chaplain.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.Nm = entity.Nm;
                        updatedRecord.Note = entity.Note;
                        updatedRecord.FirstName = entity.FirstName;
                        updatedRecord.LastName = entity.LastName;
                        updatedRecord.PostalAddress = entity.PostalAddress;
                        updatedRecord.PASuburbID = entity.PASuburbID;
                        updatedRecord.Phone1 = entity.Phone1;
                        updatedRecord.Phone2 = entity.Phone2;
                        updatedRecord.email = entity.email;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.Chaplain.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteChaplain(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.Chaplain.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<ChaplainVM>> GetAllChaplain()
        {
            try
            {
                // Retrieve list from the database
                List<ChaplainVM> list = (from sr in _context.Chaplain
                                         join su in _context.Suburb on
                                         sr.PASuburbID equals su.ID
                                         where sr.PASuburbID == su.ID
                                         select new ChaplainVM
                                         {
                                             ID = sr.ID,
                                             Nm = sr.Nm,
                                             Note = sr.Note,
                                             FirstName = sr.FirstName,
                                             LastName = sr.LastName,
                                             PostalAddress = sr.PostalAddress,
                                             Phone1 = sr.Phone1,
                                             Phone2 = sr.Phone2,
                                             email = sr.email,
                                             PASuburbID = sr.PASuburbID,
                                             SuburbName = su.Nm
                                         }).ToList();

                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<ChaplainVM>>(null);
            }
        }

        public Task<ChaplainVM> GetSingleChaplainWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.Chaplain.Any(a => a.ID.ToString() == id))
                {
                    Chaplain mdoel = _context.Chaplain.First(a => a.ID.ToString() == id);
                    ChaplainVM data = _mapper.Map<ChaplainVM>(mdoel);
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
