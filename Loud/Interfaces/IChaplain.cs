using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IChaplain
    {
        Task<ErrorVM> CreateNEditChaplain(ChaplainVM model, string id = "");
        Task<List<ChaplainVM>> GetAllChaplain();
        Task<ErrorVM> DeleteChaplain(string id);
        Task<ChaplainVM> GetSingleChaplainWithSearch(string id);
    }
}
