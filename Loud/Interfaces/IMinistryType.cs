using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IMinistryType
    {
        Task<ErrorVM> CreateNEditMinistryType(MinistryTypeVM model, string id = "");
        Task<List<MinistryType>> GetAllMinistryType();
        Task<ErrorVM> DeleteMinistryType(string id);
        Task<MinistryTypeVM> GetSingleMinistryTypeWithSearch(string id);
    }
}
