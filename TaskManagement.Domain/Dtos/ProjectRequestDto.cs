using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Common.Dtos
{
    public class ProjectRequestDto
    {
        public string? ProjectDescription { get; set; }
        public List<TaskDto> taskRequestDtos { get; set; }
    }
}
