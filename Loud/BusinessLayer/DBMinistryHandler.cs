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
    public class DBMinistryHandler : IMinistry
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBMinistryHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditMinistry(MinistryVM model, string id = "")
        {

            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<Ministry>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.Ministry.AddAsync(entity);
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
                    Ministry entity = _mapper.Map<Ministry>(model);
                    Ministry updatedRecord = await _context.Ministry.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.ChurchID = entity.ChurchID;
                        updatedRecord.MinistryTypeID = entity.MinistryTypeID;
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
                        updatedRecord.Note = entity.Note;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.Ministry.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteMinistry(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.Ministry.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<MinistryVM>> GetAllMinistry()
        {
            try
            {
                // Retrieve list from the database
                List<MinistryVM> list = (from min in _context.Ministry
                                         join su in _context.Suburb on
                                         min.PASuburbID equals su.ID
                                         where min.PASuburbID == su.ID
                                         join chur in _context.Church on
                                         min.ChurchID equals chur.ID
                                         where min.ChurchID == chur.ID
                                         join mintype in _context.MinistryType on
                                         min.MinistryTypeID equals mintype.ID
                                         where min.MinistryTypeID == mintype.ID
                                         select new MinistryVM
                                         {
                                             ID = min.ID,
                                             Note = min.Note,
                                             FirstName = min.FirstName,
                                             LastName = min.LastName,
                                             StreetAddress = min.StreetAddress,
                                             SASuburbID = min.SASuburbID,
                                             PASameAsSA = min.PASameAsSA,
                                             PostalAddress = min.PostalAddress,
                                             PASuburbID = min.PASuburbID,
                                             Fax = min.Fax,
                                             Phone1 = min.Phone1,
                                             Phone2 = min.Phone2,
                                             email = min.email,
                                             SASuburbName = su.Nm,
                                             PASuburbName = su.Nm,
                                             ChurchID = chur.ID,
                                             ChurchName = chur.Nm,
                                             MinistryTypeID = mintype.ID,
                                             MinistryTypeName = mintype.Nm
                                         }).ToList();

                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<MinistryVM>>(null);
            }
        }

        public Task<List<MinistryVM>> GetAllMinistrysWithChurch(string cID)
        {
            int cid = Convert.ToInt32(cID);
            try
            {
                // Retrieve list from the database
                List<MinistryVM> list = (from min in _context.Ministry
                                         join su in _context.Suburb on
                                         min.PASuburbID equals su.ID
                                         where min.PASuburbID == su.ID
                                         join chur in _context.Church on
                                         min.ChurchID equals chur.ID
                                         where min.ChurchID == cid
                                         join mintype in _context.MinistryType on
                                         min.MinistryTypeID equals mintype.ID
                                         where min.MinistryTypeID == mintype.ID
                                         select new MinistryVM
                                         {
                                             ID = min.ID,
                                             Note = min.Note,
                                             FirstName = min.FirstName,
                                             LastName = min.LastName,
                                             StreetAddress = min.StreetAddress,
                                             SASuburbID = min.SASuburbID,
                                             PASameAsSA = min.PASameAsSA,
                                             PostalAddress = min.PostalAddress,
                                             PASuburbID = min.PASuburbID,
                                             Fax = min.Fax,
                                             Phone1 = min.Phone1,
                                             Phone2 = min.Phone2,
                                             email = min.email,
                                             SASuburbName = su.Nm,
                                             PASuburbName = su.Nm,
                                             ChurchID = chur.ID,
                                             ChurchName = chur.Nm,
                                             MinistryTypeID = mintype.ID,
                                             MinistryTypeName = mintype.Nm
                                         }).ToList();

                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<MinistryVM>>(null);
            }
        }
        public Task<MinistryVM> GetSingleMinistryWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.Ministry.Any(a => a.ID.ToString() == id))
                {
                    Ministry mdoel = _context.Ministry.First(a => a.ID.ToString() == id);
                    MinistryVM data = _mapper.Map<MinistryVM>(mdoel);
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
