using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
#nullable enable
    public class UsersModel
    {
        public string username { get; set; }
        public string? password { get; set; }
        public int? retry { get; set; }
        public int? userStatus { get; set; }
        public int? access { get; set; }

       
        public UsersModel(string username, string? password, int? retry, int? userStatus, int? access)
        {
            this.username = username;
            this.password = password;
            this.retry = retry;
            this.userStatus = userStatus;
            this.access = access;
        }

        
    }

}
