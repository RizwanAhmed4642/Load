using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IChaplainTaskType
    {
        Task<ErrorVM> CreateNEditChaplainTaskType(ChaplainTaskTypeVM model, string id = "");
        Task<List<ChaplainTaskType>> GetAllChaplainTaskType();
        Task<ErrorVM> DeleteChaplainTaskType(string id);
        Task<ChaplainTaskTypeVM> GetSingleChaplainTaskTypeWithSearch(string id);
    }
}
