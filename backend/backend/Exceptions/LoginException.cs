using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {
             
        }
    }
}
