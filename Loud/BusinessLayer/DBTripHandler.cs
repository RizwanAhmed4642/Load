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
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace SAS.BusinessLayer
{

    public class DBTripHandler : ITrip
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBTripHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditTrip(TripVM model, string id = "")
        {

            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<Trip>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.Trip.AddAsync(entity);
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
                    Trip entity = _mapper.Map<Trip>(model);
                    Trip updatedRecord = await _context.Trip.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.StartDate = entity.StartDate;
                        updatedRecord.Subject = entity.Subject;
                        updatedRecord.SRERepID = entity.SRERepID;
                        updatedRecord.CompletedDate = entity.CompletedDate;
                        updatedRecord.Note = entity.Note;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.Trip.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteTrip(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.Trip.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<TripVM>> GetAllTrip()
        {
            try
            {
                // Retrieve list from the database
                List<TripVM> list = (from trip in _context.Trip
                                     join sre in _context.SRERep on
                                     trip.SRERepID equals sre.ID
                                     where trip.SRERepID == sre.ID
                                     select new TripVM
                                     {
                                         ID = trip.ID,
                                         StartDate = trip.StartDate,
                                         Subject = trip.Subject,
                                         SRERepID = trip.SRERepID,
                                         SRERepName = sre.FirstName,
                                         CompletedDate = trip.CompletedDate,
                                         Note = trip.Note,
                                     }).ToList();

                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<TripVM>>(null);
            }
        }

        public Task<TripVM> GetSingleTripWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.Trip.Any(a => a.ID.ToString() == id))
                {
                    Trip mdoel = _context.Trip.First(a => a.ID.ToString() == id);
                    TripVM data = _mapper.Map<TripVM>(mdoel);
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
