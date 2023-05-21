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
    public class DBSchoolGradeHandler : ISchoolGrade
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBSchoolGradeHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditSchoolGrade(SchoolGradeVM model, string id = "")
        {
            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<SchoolGrade>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.SchoolGrade.AddAsync(entity);
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
                    SchoolGrade entity = _mapper.Map<SchoolGrade>(model);
                    SchoolGrade updatedRecord = await _context.SchoolGrade.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.Nm = entity.Nm;
                        updatedRecord.MinYear = entity.MinYear;
                        updatedRecord.MaxYear = entity.MinYear;
                        updatedRecord.Default = entity.Default;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.SchoolGrade.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteSchoolGrade(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.SchoolGrade.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<SchoolGrade>> GetAllSchoolGrade()
        {
            try
            {
                // Retrieve list from the database
                List<SchoolGrade> list = _context.SchoolGrade.ToList();
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates a Task that represents a precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<SchoolGrade>>(null);
            }
        }

        public Task<SchoolGradeVM> GetSingleSchoolGradeWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.SchoolGrade.Any(a => a.ID.ToString() == id))
                {
                    SchoolGrade mdoel = _context.SchoolGrade.First(a => a.ID.ToString() == id);
                    SchoolGradeVM data = _mapper.Map<SchoolGradeVM>(mdoel);
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
