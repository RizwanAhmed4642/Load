using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface ISRECoordinatorTask
    {
        Task<ErrorVM> CreateNEditSRECoordinatorTask(SRECoordinatorTaskVM model, string id = "");
        Task<List<SRECoordinatorTaskVM>> GetAllSRECoordinatorTask();
        Task<ErrorVM> DeleteSRECoordinatorTask(string id);
        Task<SRECoordinatorTaskVM> GetSingleSRECoordinatorTaskWithSearch(string id);
    }
}
