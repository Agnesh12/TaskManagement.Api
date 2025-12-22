using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Common.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string? ProjectDescription { get; set; }
        public List<TaskItem> Tasks { get; set; }

    }
}
