﻿using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public interface IUsersService
    {
        LoginResponseModel loginService(String username, string password);
        ClientRegistrationResponseModel registerService(ClientRegistrationRequestModel registrationData);
        bool resetPassword(string username, string oldPassword, string newPassword, int status);
        bool forgotPassword(string companyRegistration,string email,string phone);
    }
}
