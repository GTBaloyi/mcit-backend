using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    public interface IProductService
    {
        void getAllProducts();
        void getMouldingTechProducts();
        void getFoundryTechProducts();
        void getPhysicalMetallurgyProducts();
        void getBroaderMCTSRatesProducts();
        void getSupportProducts();
    }
}
