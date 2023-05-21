using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface ISRECoordinator
    {
        Task<ErrorVM> CreateNEditSRECoordinator(SRECoordinatorVM model, string id = "");
        Task<List<SRECoordinatorVM>> GetAllSRECoordinator();
        Task<ErrorVM> DeleteSRECoordinator(string id);
        Task<SRECoordinatorVM> GetSingleSRECoordinatorWithSearch(string id);
    }
}
