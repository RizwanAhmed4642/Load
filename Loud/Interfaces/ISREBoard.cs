using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface ISREBoard
    {
        Task<ErrorVM> CreateNEditSREBoard(SREBoardVM model, string id = "");
        Task<List<SREBoardVM>> GetAllSREBoard();
        Task<ErrorVM> DeleteSREBoard(string id);
        Task<SREBoardVM> GetSingleSREBoardWithSearch(string id);
    }
}
