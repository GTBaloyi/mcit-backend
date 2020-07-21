using backend.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    public interface IProductService
    {
        List<AllProductsResponseModel> getAllProducts();
        List<AllProductsResponseModel> getProductsByFocusArea(string focusArea);
        List<FocusAreaModel> getAllFocusAreas();
    }
}
