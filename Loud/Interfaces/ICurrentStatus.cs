using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface ICurrentStatus
    {
        Task<ErrorVM> CreateNEditCurrentStatus(CurrentStatusVM model, string id = "");
        Task<List<CurrentStatusVM>> GetAllCurrentStatus();
        Task<ErrorVM> DeleteCurrentStatus(string id);
        Task<CurrentStatusVM> GetSingleCurrentStatusWithSearch(string id);
    }
}
