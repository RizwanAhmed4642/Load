using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IChurch
    {
        Task<ErrorVM> CreateNEditChurch(ChurchVM model, string id = "");
        Task<List<ChurchVM>> GetAllChurch();
        Task<List<ChurchVM>> GetAllChurchsWithHighSchool(string hsID);
        Task<ErrorVM> DeleteChurch(string id);
        Task<ChurchVM> GetSingleChurchWithSearch(string id);
    }
}
