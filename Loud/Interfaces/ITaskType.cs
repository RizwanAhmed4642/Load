using SAS.Models.ViewModels.GeneralViewModels;
using SAS.Models.ViewModels.SASViewModels;
using SAS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface ITaskType
    {
        Task<ErrorVM> CreateNEditTaskType(TaskTypeVM model, string id = "");
        Task<List<TaskType>> GetAllTaskType();
        Task<ErrorVM> DeleteTaskType(string id);
        Task<TaskTypeVM> GetSingleTaskTypeWithSearch(string id);
    }
}
