﻿using backend.Models.Request;
using backend.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    public interface IQuotationService
    {
        public bool NewQuotation(QuotationModel model);
        public QuotationResponseModel GetById(int id);
        public List<QuotationResponseModel> GetAll();
        public void Delete(int id);
        public QuotationResponseModel Update(QuotationModel model);
    }
}
