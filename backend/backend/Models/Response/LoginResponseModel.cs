﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class LoginResponseModel
    {

        public LoginResponseModel(string name, string surname, string picture, int accessLevel, bool isLoggedIn, int userStatus)
        {
            this.name = name;
            this.surname = surname;
            this.picture = picture;
            this.loggedIn = isLoggedIn;
            this.accessLevel = accessLevel;
            this.userStatus = userStatus;
        }

        public string name { get; set; }
        public string surname { get; set; }
        public string? picture { get; set; }
        public bool loggedIn { get; set; }
        public int accessLevel { get; set; }
        public int userStatus { get; set; }
    }
}
