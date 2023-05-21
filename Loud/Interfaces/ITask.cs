using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface ITask
    {
        Task<ErrorVM> CreateNEditTask(TaskVM model, string id = "");
        Task<List<TaskVM>> GetAllTask();
        Task<List<TaskVM>> GetAllTasksWithHighSchool(string hsID, string venueTypeID);
        Task<List<TaskVM>> GetAllTasksWithPrimarySchool(string psID, string venueTypeID);
        Task<List<TaskVM>> GetAllTasksWithChurch(string cID, string venueTypeID);
        Task<ErrorVM> DeleteTask(string id);
        Task<TaskVM> GetSingleTaskWithSearch(string id);
    }
}
