using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface ISchoolGrade
    {
        Task<ErrorVM> CreateNEditSchoolGrade(SchoolGradeVM model, string id = "");
        Task<List<SchoolGrade>> GetAllSchoolGrade();
        Task<ErrorVM> DeleteSchoolGrade(string id);
        Task<SchoolGradeVM> GetSingleSchoolGradeWithSearch(string id);
    }
}
