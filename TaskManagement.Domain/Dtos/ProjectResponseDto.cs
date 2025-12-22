using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Common.Dtos
{
    public class ProjectResponseDto
    {
        public string? ProjectDescription { get; set; }
        public List<TaskResponseDto> Tasks{ get; set;}
    }
}
