using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IMinister
    {
        Task<ErrorVM> CreateNEditMinister(MinisterVM model, string id = "");
        Task<List<MinisterVM>> GetAllMinister();
        Task<ErrorVM> DeleteMinister(string id);
        Task<MinisterVM> GetSingleMinisterWithSearch(string id);
    }
}
