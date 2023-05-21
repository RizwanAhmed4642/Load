using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IGeoAccuracy
    {
        Task<ErrorVM> CreateNEditGeoAccuracy(GeoAccuracyVM model, string id = "");
        Task<List<GeoAccuracyVM>> GetAllGeoAccuracy();
        Task<ErrorVM> DeleteGeoAccuracy(string id);
        Task<GeoAccuracyVM> GetSingleGeoAccuracyWithSearch(string id);
    }
}
