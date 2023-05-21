using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IPrimarySchool
    {
        Task<ErrorVM> CreateNEditPrimarySchool(PrimarySchoolVM model, string id = "");
        Task<List<PrimarySchoolVM>> GetAllPrimarySchool(string type = "Public");
        Task<List<PrimarySchoolVM>> GetAllPrimaryShcoolsWithHighSchool(string hsID);
        Task<ErrorVM> DeletePrimarySchool(string id);
        Task<PrimarySchoolVM> GetSinglePrimarySchoolWithSearch(string id);
    }
}
