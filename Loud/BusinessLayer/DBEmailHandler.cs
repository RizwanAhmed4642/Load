using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SAS.Data;
using SAS.Interfaces;
using SAS.Models;
using SAS.Models.SASModels;
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
    public class DBEmailHandler : IEmail
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DBEmailHandler(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IMapper mapper, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ErrorVM> CreateNEditEmail(EmailVM model, string id = "")
        {

            if (id == "")
            {
                try
                {
                    var entity = _mapper.Map<Email>(model);
                    entity.Created_At = DateTime.Now;
                    entity.Created_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    await _context.Emails.AddAsync(entity);
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
                    Email entity = _mapper.Map<Email>(model);
                    Email updatedRecord = await _context.Emails.FindAsync(model.ID);

                    if (updatedRecord == null)
                    {
                        return new ErrorVM { Status = false, ErrorCode = "404", Message = "Record not found" };
                    }
                    else
                    {
                        updatedRecord.FromEmail = entity.FromEmail;
                        updatedRecord.ToEmail = entity.ToEmail;
                        updatedRecord.Subject = entity.Subject;
                        updatedRecord.Body = entity.Body;
                        updatedRecord.Updated_At = DateTime.Now;
                        updatedRecord.Updated_By = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        _context.Emails.Update(updatedRecord);
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

        public Task<ErrorVM> DeleteEmail(string id)
        {
            try
            {
                if (id != "")
                {
                    _context.Remove(_context.Emails.Single(a => a.ID.ToString() == id));
                    _context.SaveChanges();
                }
                return Task.FromResult(new ErrorVM { Status = true, ErrorCode = "200", Message = "Deleted Successfully" });
            }
            catch (Exception exe)
            {
                return Task.FromResult(new ErrorVM { Status = false, ErrorCode = "404", Message = exe.Message });
            }
        }

        public Task<List<EmailVM>> GetAllEmail()
        {
            try
            {
                // Retrieve list from the database
                List<EmailVM> list = (from email in _context.Emails
                                      join user in _userManager.Users on
                                      email.Created_By equals user.Id
                                      where email.Created_By == user.Id
                                      select new EmailVM
                                      {
                                          ID = email.ID,
                                          FromEmail = email.FromEmail,
                                          ToEmail = email.ToEmail,
                                          Subject = email.Subject,
                                          Body = email.Body,
                                          Sendby = user.UserName
                                      }).ToList();

                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult(list);
            }
            catch (Exception)
            {
                //The Task.FromResult method creates sr Task that represents sr precompleted operation.
                //In this case, the operation is returning the list of list.
                return Task.FromResult<List<EmailVM>>(null);
            }
        }

        public Task<EmailVM> GetSingleEmailWithSearch(string id)
        {
            try
            {
                //Check collection is not empty before using the First method.
                if (_context.Emails.Any(a => a.ID.ToString() == id))
                {
                    Email mdoel = _context.Emails.First(a => a.ID.ToString() == id);
                    EmailVM data = _mapper.Map<EmailVM>(mdoel);
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
