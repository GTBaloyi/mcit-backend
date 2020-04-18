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
        EnquiryResponseModel NewEnquiry(int id, int focusAreaId, DateTime enquiryDate, string quarter, string company, string companyRegistrationNumber, string description, int serviceTechId, int socioEconomicImpactId, int productExpectationid, double projectBudget, DateTime expectedCompletion);
        EnquiryRequestModel GetById(int id);
        EnquiryResponseModel Save(EnquiryEntity entity);
        List<EnquiryRequestModel> GetAll();
        void Delete(int id);
        EnquiryResponseModel Update(EnquiryRequestModel model);


    }
}
