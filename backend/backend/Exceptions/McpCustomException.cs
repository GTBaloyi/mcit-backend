using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Exceptions
{
    public class McpCustomException : Exception
    {
        public McpCustomException(string message) : base(message)
        {
             
        }
    }
}
