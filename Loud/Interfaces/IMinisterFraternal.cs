using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IMinisterFraternal
    {
        Task<ErrorVM> CreateNEditMinisterFraternal(MinisterFraternalVM model, string id = "");
        Task<List<MinisterFraternalVM>> GetAllMinisterFraternal();
        Task<ErrorVM> DeleteMinisterFraternal(string id);
        Task<MinisterFraternalVM> GetSingleMinisterFraternalWithSearch(string id);
    }
}
