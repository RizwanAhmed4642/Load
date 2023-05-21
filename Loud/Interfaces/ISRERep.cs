using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface ISRERep
    {
        Task<ErrorVM> CreateNEditSRERep(SRERepVM model, string id = "");
        Task<List<SRERepVM>> GetAllSRERep();
        Task<ErrorVM> DeleteSRERep(string id);
        Task<SRERepVM> GetSingleSRERepWithSearch(string id);
    }
}
