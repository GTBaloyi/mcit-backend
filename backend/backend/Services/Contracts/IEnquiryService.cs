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
        EnquiryResponseModel NewEnquiry(EnquiryRequestModel model);
        EnquiryRequestModel GetById(int id);
        EnquiryResponseModel Save(EnquiryEntity entity);
        List<EnquiryRequestModel> GetAll();
        void Delete(int id);
        EnquiryResponseModel Update(EnquiryRequestModel model);


    }
}
