using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Common.Exceptions
{
    public class ErrorResult
    {
        public bool success { get; set; }
        public string Message { get; set; }
        public ErrorResult()
        {
            this.success = false;
            this.Message = "An error occured while processing your request";
        }
    }
}
