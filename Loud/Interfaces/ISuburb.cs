using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface ISuburb
    {
        Task<ErrorVM> CreateNEditSuburb(SuburbVM model, string id = "");
        Task<List<SuburbVM>> GetAllSuburb();
        Task<ErrorVM> DeleteSuburb(string id);
        Task<SuburbVM> GetSingleSuburbWithSearch(string id);
    }
}
