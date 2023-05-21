using SAS.Models;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IArea
    {
        Task<ErrorVM> CreateNEditArea(AreaVM model,string id="");
        Task<List<Area>> GetAllArea();
        Task<ErrorVM> DeleteArea(string id);
        Task<AreaVM> GetSingleAreaWithSearch(string id);
    }
}
