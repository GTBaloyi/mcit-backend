using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class ErrorMessage
    {
        public int error_code { get; set; }
        public string error_message { get; set; }
        public ErrorMessage(int errorCode, string errorMessage)
        {
            error_code = errorCode;
            error_message = errorMessage;
        }
    }
}
