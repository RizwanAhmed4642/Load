using SAS.Models;
using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IHighSchool
    {
        Task<ErrorVM> CreateNEditHighSchool(HighSchoolVM model, string id = "");
        Task<List<HighSchoolVM>> GetAllHighSchool(string type = "Public", int start = 0, int length = 100, string search = "");
        Task<ErrorVM> DeleteHighSchool(string id);
        Task<HighSchoolVM> GetSingleHighSchoolWithSearch(string id);
    }
}
