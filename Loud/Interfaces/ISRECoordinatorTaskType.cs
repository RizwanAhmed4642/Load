using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface ISRECoordinatorTaskType
    {
        Task<ErrorVM> CreateNEditSRECoordinatorTaskType(SRECoordinatorTaskTypeVM model, string id = "");
        Task<List<SRECoordinatorTaskType>> GetAllSRECoordinatorTaskType();
        Task<ErrorVM> DeleteSRECoordinatorTaskType(string id);
        Task<SRECoordinatorTaskTypeVM> GetSingleSRECoordinatorTaskTypeWithSearch(string id);
    }
}
