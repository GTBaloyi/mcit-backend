using backend.Models.Response;
using backend.Models.Request;
using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    public interface IEnquiryService
    {
        bool NewEnquiry(EnquiryRequestModel model);
        EnquiryResponseModel GetById(int id);
        List<EnquiryResponseModel> GetAll();
        void Delete(int id);
        EnquiryResponseModel Update(EnquiryRequestModel model);


    }
}
