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
    public class DBSuburbHandler : ISuburb
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBSuburbHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ErrorVM> CreateNEditSuburb(SuburbVM model, string id = "")
        {
            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<Suburb>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.Suburb.AddAsync(entity);
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
                    Suburb entity = _mapper.Map<Suburb>(model);
                    Suburb updatedRecord = await _context.Suburb.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.Nm = entity.Nm;
                        updatedRecord.StateID = entity.StateID;
                        updatedRecord.PostCode = entity.PostCode;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.Suburb.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteSuburb(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.Suburb.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<SuburbVM>> GetAllSuburb()
        {
            try
            {
                // Retrieve list from the database
                //List<Suburb> list = _context.Suburb.ToList();
                List<SuburbVM> list = (from sub in _context.Suburb
                                       join st in _context.State on
                                       sub.StateID equals st.ID
                                       where sub.StateID == st.ID
                                       select new SuburbVM
                                       {
                                           ID = sub.ID,
                                           Nm = sub.Nm,
                                           PostCode = sub.PostCode,
                                           StateID = st.ID,
                                           StateName = st.Nm
                                       }).ToList();

                //The Task.FromResult method creates sub Task that represents sub precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sub Task that represents sub precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<SuburbVM>>(null);
            }
        }

        public Task<SuburbVM> GetSingleSuburbWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.Suburb.Any(a => a.ID.ToString() == id))
                {
                    Suburb mdoel = _context.Suburb.First(a => a.ID.ToString() == id);
                    SuburbVM data = _mapper.Map<SuburbVM>(mdoel);
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
