using AutoMapper;
using TaskManagement.Common.Dtos;
using TaskManagement.Common.Entities;

namespace TaskManagement.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskDto, TaskItem>();
            CreateMap<TaskItem, TaskResponseDto>();
            CreateMap<ProjectResponseDto, Project>()
            .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));
            CreateMap<Project, ProjectResponseDto>();
            CreateMap<Project, ProjectRequestDto>();
        }
    }
}
