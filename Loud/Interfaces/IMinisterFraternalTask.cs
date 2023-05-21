using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IMinisterFraternalTask
    {
        Task<ErrorVM> CreateNEditMinisterFraternalTask(MinisterFraternalTaskVM model, string id = "");
        Task<List<MinisterFraternalTaskVM>> GetAllMinisterFraternalTask();
        Task<ErrorVM> DeleteMinisterFraternalTask(string id);
        Task<MinisterFraternalTaskVM> GetSingleMinisterFraternalTaskWithSearch(string id);
    }
}
