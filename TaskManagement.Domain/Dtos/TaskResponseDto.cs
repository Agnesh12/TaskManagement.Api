using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Common.Dtos
{
    public class TaskResponseDto
    {
        public string TaskTitle { get; set; }

        public string TaskDescription { get; set; }
        public string TaskStatus { get; set; }
    }
}
