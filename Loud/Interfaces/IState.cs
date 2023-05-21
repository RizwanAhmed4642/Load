using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IState
    {
        Task<ErrorVM> CreateNEditState(StateVM model, string id = "");
        Task<List<State>> GetAllState();
        Task<ErrorVM> DeleteState(string id);
        Task<StateVM> GetSingleStateWithSearch(string id);
    }
}
