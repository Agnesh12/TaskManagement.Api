using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
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
            CreateMap<ProjectRequestDto, Project>();
            CreateMap<Project, ProjectResponseDto>();
        }
    }
}
