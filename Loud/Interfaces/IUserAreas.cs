using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface IUserAreas
    {
        Task<ErrorVM> CreateNEditUserArea(UserAreasVM model, string id = "");
        Task<List<UserAreas>> GetAllUserArea();
        Task<List<UserAreasVM>> GetAllUserAreasWithUserID(string UserID);
        Task<List<GoogleMapPinsVM>> GetAllUserAreasAndVenus(int areaID = 0);
        Task<List<GoogleMapPinsVM>> GetAllUserAreasAndVenusWithUserID(string UserID, int areaID = 0);
        Task<List<GoogleMapPinsVM>> GetAllUserAreasAndHighSchoolVenus(int areaID = 0);
        Task<List<GoogleMapPinsVM>> GetAllUserAreasAndHighSchoolVenusWithUserID(string UserID, int areaID = 0);
        Task<List<GoogleMapPinsVM>> GetAllUserAreasAndPrimarySchoolVenus(int areaID = 0);
        Task<List<GoogleMapPinsVM>> GetAllUserAreasAndPrimarySchoolVenusWithUserID(string UserID, int areaID = 0);
        Task<List<GoogleMapPinsVM>> GetAllUserAreasAndChurchVenus(int areaID = 0);
        Task<List<GoogleMapPinsVM>> GetAllUserAreasAndChurchVenusWithUserID(string UserID, int areaID = 0);
        Task<ErrorVM> DeleteUserArea(string id);
        Task<ErrorVM> DeleteUserAreaWithUserID(string UserID);
        Task<UserAreas> GetSingleUserAreaWithSearch(string id);
    }

}
