using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IMinistry
    {
        Task<ErrorVM> CreateNEditMinistry(MinistryVM model, string id = "");
        Task<List<MinistryVM>> GetAllMinistry(); 
        Task<List<MinistryVM>> GetAllMinistrysWithChurch(string cID);
        Task<ErrorVM> DeleteMinistry(string id);
        Task<MinistryVM> GetSingleMinistryWithSearch(string id);
    }
}
