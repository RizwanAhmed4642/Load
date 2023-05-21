using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IChaplainTask
    {
        Task<ErrorVM> CreateNEditChaplainTask(ChaplainTaskVM model, string id = "");
        Task<List<ChaplainTaskVM>> GetAllChaplainTask();
        Task<ErrorVM> DeleteChaplainTask(string id);
        Task<ChaplainTaskVM> GetSingleChaplainTaskWithSearch(string id);
    }
}
