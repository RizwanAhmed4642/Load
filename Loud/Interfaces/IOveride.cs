using SAS.Models;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IOveride
    {
        Task<ErrorVM> CreateNEditOveride(OverideVM model, string id = "");
        Task<List<Overide>> GetAllOveride();
        Task<ErrorVM> DeleteOveride(string id);
        Task<OverideVM> GetSingleOverideWithSearch(string id);
    }
}
