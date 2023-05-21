using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface ISREBoardTask
    {
        Task<ErrorVM> CreateNEditSREBoardTask(SREBoardTaskVM model, string id = "");
        Task<List<SREBoardTaskVM>> GetAllSREBoardTask();
        Task<ErrorVM> DeleteSREBoardTask(string id);
        Task<SREBoardTaskVM> GetSingleSREBoardTaskWithSearch(string id);
    }
}
