using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class ClientRegistrationResponseModel
    {
        public ClientRegistrationResponseModel(int code, string description)
        {
            this.code = code;
            this.description = description;
        }
        public int code { get; set; }
        public string description { get; set; }
    }
}
