using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    public interface IProductRepository
    {
         List<ProductsEntity> GetAll();
         ProductsEntity GetById(int id);
        ProductsEntity GetByName(string productName);
        List<ProductsEntity> GetByFocusArea(int focusAreaId);
         bool Save(ProductsEntity product);
         bool Update(ProductsEntity product);
         bool Delete(ProductsEntity product);
    }
}
