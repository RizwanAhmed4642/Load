using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface ITrip
    {
        Task<ErrorVM> CreateNEditTrip(TripVM model, string id = "");
        Task<List<TripVM>> GetAllTrip();
        Task<ErrorVM> DeleteTrip(string id);
        Task<TripVM> GetSingleTripWithSearch(string id);
    }
}
