using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IMinisterFraternalTaskType
    {
        Task<ErrorVM> CreateNEditMinisterFraternalTaskType(MinisterFraternalTaskTypeVM model, string id = "");
        Task<List<MinisterFraternalTaskType>> GetAllMinisterFraternalTaskType();
        Task<ErrorVM> DeleteMinisterFraternalTaskType(string id);
        Task<MinisterFraternalTaskTypeVM> GetSingleMinisterFraternalTaskTypeWithSearch(string id);
    }
}
