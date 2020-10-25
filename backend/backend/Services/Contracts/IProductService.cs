using backend.DataAccess.Database.Entities;
using backend.Models.Request;
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
        AllProductsResponseModel getProductByName(string name);
        FocusAreaModel getFocusArea(string name);
        bool createProduct(ProductRequestModel product);
        bool createFocusArea(string focusArea);
        bool updateProduct(ProductRequestModel product);
        bool updateFocusArea(FocusAreaModel focusArea);
        bool deleteProduct(int productId);
        bool deleteFocusArea(string name);
    }
}
