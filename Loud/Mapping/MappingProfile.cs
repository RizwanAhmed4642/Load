using SAS.Models;
using SAS.Models.ViewModels.SASViewModels;
using AutoMapper;
using SAS.Models.SASModels;

namespace SAS.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AreaVM, Area>().ReverseMap();
            CreateMap<StateVM, State>().ReverseMap();
            CreateMap<EmailVM, Email>().ReverseMap();
            CreateMap<SuburbVM, Suburb>().ReverseMap();
            CreateMap<GeoAccuracyVM, GeoAccuracy>().ReverseMap();
            CreateMap<SREBoardVM, SREBoard>().ReverseMap();
            CreateMap<SREBoardTaskVM, SREBoardTask>().ReverseMap();
            CreateMap<SREBoardTaskTypeVM, SREBoardTaskType>().ReverseMap();
            CreateMap<SRERepVM, SRERep>().ReverseMap();
            CreateMap<SRECoordinatorVM, SRECoordinator>().ReverseMap();
            CreateMap<SRECoordinatorTaskTypeVM, SRECoordinatorTaskType>().ReverseMap();
            CreateMap<ChaplainVM, Chaplain>().ReverseMap();
            CreateMap<ChaplainTaskVM, ChaplainTask>().ReverseMap();
            CreateMap<ChaplainTaskTypeVM, ChaplainTaskType>().ReverseMap();
            CreateMap<ChurchVM, Church>().ReverseMap();
            CreateMap<CurrentStatusVM, CurrentStatus>().ReverseMap();
            CreateMap<UserAreasVM, UserAreas>().ReverseMap();
            CreateMap<OverideVM, Overide>().ReverseMap();
            CreateMap<MinisterVM, Minister>().ReverseMap();
            CreateMap<MinistryVM, Ministry>().ReverseMap();
            CreateMap<MinistryTypeVM, MinistryType>().ReverseMap();
            CreateMap<MinisterFraternalVM, MinisterFraternal>().ReverseMap();
            CreateMap<MinisterFraternalTaskVM, MinisterFraternalTask>().ReverseMap();
            CreateMap<MinisterFraternalTaskTypeVM, MinisterFraternalTaskType>().ReverseMap();
            CreateMap<TaskTypeVM, TaskType>().ReverseMap();
            CreateMap<TaskVM, Task>().ReverseMap();
            CreateMap<TripVM, Trip>().ReverseMap();
            CreateMap<SRECoordinatorTaskVM, SRECoordinatorTask>().ReverseMap();
            CreateMap<SchoolGradeVM, SchoolGrade>().ReverseMap();
            CreateMap<HS_SchoolGradeVM, HS_SchoolGrade>().ReverseMap();
            CreateMap<PrimarySchoolVM, PrimarySchool>().ReverseMap();
            CreateMap<HighSchoolVM, HighSchool>().ReverseMap();
        }
    }
}
