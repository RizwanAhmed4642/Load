using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IEmail
    {
        Task<ErrorVM> CreateNEditEmail(EmailVM model, string id = "");
        Task<List<EmailVM>> GetAllEmail();
        Task<ErrorVM> DeleteEmail(string id);
        Task<EmailVM> GetSingleEmailWithSearch(string id);
    }
}
