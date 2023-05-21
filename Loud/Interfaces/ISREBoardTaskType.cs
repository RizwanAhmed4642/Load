using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface ISREBoardTaskType
    {
        Task<ErrorVM> CreateNEditSREBoardTaskType(SREBoardTaskTypeVM model, string id = "");
        Task<List<SREBoardTaskType>> GetAllSREBoardTaskType();
        Task<ErrorVM> DeleteSREBoardTaskType(string id);
        Task<SREBoardTaskTypeVM> GetSingleSREBoardTaskTypeWithSearch(string id);
    }
}
