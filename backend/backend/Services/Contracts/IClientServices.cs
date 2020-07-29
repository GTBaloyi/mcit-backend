using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    public interface IClientServices
    {
        bool UpdateClient(ClientRegistrationRequestModel client);
        bool DeleteClient(string companyRegistrationNumber);
        ClientRegistrationRequestModel GetClient(string companyRegistrationNumber);
        List<ClientRegistrationRequestModel> GetAllClients();
    }
}
