using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IHS_SchoolGrade
    {
        Task<ErrorVM> CreateNEditHS_SchoolGrade(HS_SchoolGradeVM model, string id = "");
        Task<List<HS_SchoolGradeVM>> GetAllHS_SchoolGrade();
        Task<List<HS_SchoolGradeVM>> GetAllHSGWithHighSchool(string hsID);
        Task<List<HS_SchoolGradeVM>> GetAllHSGWithPrimarySchool(string psID);
        Task<ErrorVM> DeleteHS_SchoolGrade(string id);
        Task<HS_SchoolGradeVM> GetSingleHS_SchoolGradeWithSearch(string id);
    }
}
