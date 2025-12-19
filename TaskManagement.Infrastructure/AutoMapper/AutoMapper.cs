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
            CreateMap<TaskItem, TaskDto>().ForMember(dis => dis.TaskTitle, src => src.MapFrom(opt => opt.TaskTitle))
                .ForMember(dis => dis.TaskDescription, src => src.MapFrom(opt => opt.TaskDescription))
                .ForMember(dis => dis.TaskStatus, src => src.MapFrom(opt => opt.TaskStatus));
        }
    }
}
