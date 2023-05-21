using SAS.Data;
using SAS.Interfaces;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using Task = System.Threading.Tasks.Task;
using System.Linq;

namespace SAS.BusinessLayer
{
    public class DBGeoAccuracyHandler : IGeoAccuracy
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBGeoAccuracyHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditGeoAccuracy(GeoAccuracyVM model, string id = "")
        {

            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<GeoAccuracy>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.GeoAccuracy.AddAsync(entity);
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
                    GeoAccuracy entity = _mapper.Map<GeoAccuracy>(model);
                    GeoAccuracy updatedRecord = await _context.GeoAccuracy.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.GoogleMeaning = entity.GoogleMeaning;
                        updatedRecord.Description = entity.Description;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.GeoAccuracy.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteGeoAccuracy(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.GeoAccuracy.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<GeoAccuracyVM>> GetAllGeoAccuracy()
        {
            try
            {
                // Retrieve list from the database
                List<GeoAccuracyVM> list = (from sr in _context.GeoAccuracy
                                            select new GeoAccuracyVM
                                            {
                                                ID = sr.ID,
                                                GoogleMeaning = sr.GoogleMeaning,
                                                Description = sr.Description,
                                            }).ToList();

                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<GeoAccuracyVM>>(null);
            }
        }

        public Task<GeoAccuracyVM> GetSingleGeoAccuracyWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.GeoAccuracy.Any(a => a.ID.ToString() == id))
                {
                    GeoAccuracy mdoel = _context.GeoAccuracy.First(a => a.ID.ToString() == id);
                    GeoAccuracyVM data = _mapper.Map<GeoAccuracyVM>(mdoel);
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
