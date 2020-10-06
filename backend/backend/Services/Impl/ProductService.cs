using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.Exceptions;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services.Builder;
using backend.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly IFocusAreaRepository _focusAreaRepo;
        private readonly IProductRepository _productRepo;
        private readonly IEntityBuilder _entityBuilder;
        public ProductService(IFocusAreaRepository focusAreaRepo, IProductRepository productRepository, IEntityBuilder entityBuilder)
        {
            _focusAreaRepo = focusAreaRepo;
            _productRepo = productRepository;
            _entityBuilder = entityBuilder;
        }

        public bool createFocusArea(string focusArea)
        {
            FocusAreaEntity fa = new FocusAreaEntity();
            fa.name = focusArea;
            return _focusAreaRepo.Save(fa);
            
        }

        public bool createProduct(ProductRequestModel product)
        {
            ProductsEntity p = _entityBuilder.buildProductEntity(0, product.name, product.timeStudyPerTest, product.ratePerHour, product.focusArea);
            return _productRepo.Save(p);
        }

        public bool deleteFocusArea(string name)
        {
            FocusAreaEntity fa = _focusAreaRepo.GetByName(name);
            if (fa!=null)
            {
                return _focusAreaRepo.Delete(fa.id);
            }
            else
            {
                throw new McpCustomException("Focus area does not exist");
            }
        }

        public bool deleteProduct(ProductRequestModel product)
        {
            if(_productRepo.GetById(product.id)!= null)
            {
                ProductsEntity p = _entityBuilder.buildProductEntity(product.id, product.name, product.timeStudyPerTest, product.ratePerHour, product.focusArea);
                return _productRepo.Delete(p);
            } 
            else
            {
                throw new McpCustomException("This product doesn't exist");
            }
        }

        public List<FocusAreaModel> getAllFocusAreas()
        {
            try
            {
                List<FocusAreaModel> focusArea = new List<FocusAreaModel>();
                foreach (FocusAreaEntity focus in _focusAreaRepo.GetAll())
                {
                    focusArea.Add(new FocusAreaModel(focus.id, focus.name));
                }
                return focusArea;
            } catch (Exception e)
            {
                throw e;
            }
            
        }

        public List<AllProductsResponseModel> getAllProducts()
        {
            try
            {
                AllProductsResponseModel product = new AllProductsResponseModel();
                List<ProductsEntity> productsEntity = _productRepo.GetAll();
                List<AllProductsResponseModel> result = new List<AllProductsResponseModel>();
                if (productsEntity != null)
                {
                    foreach (ProductsEntity prod in productsEntity)
                    {
                        product.focusAreaId = prod.focus_area_fk;
                        product.item = prod.name;
                        product.productId = prod.id;
                        product.ratePerHour = prod.rate_per_hour;
                        product.timeStudyPerTest = prod.time_study_per_test;
                        result.Add(product);
                    }
                }

                return result;
            } catch(Exception e)
            {
                throw e;
            }
        }

        public FocusAreaModel getFocusArea(string name)
        {
            FocusAreaEntity fa = _focusAreaRepo.GetByName(name);
            if (fa != null)
            {
                return new FocusAreaModel 
                { 
                    id = fa.id,
                    name = fa.name
                };
            }
            else
            {
                throw new McpCustomException("This focus area doesn't exist");
            }
        }

        public AllProductsResponseModel getProductByName(string name)
        {
            
            ProductsEntity product = _productRepo.GetByName(name);
            if (product != null)
            {
                return new AllProductsResponseModel
                {
                   focusAreaId = product.focus_area_fk,
                   item = product.name,
                   productId = product.id,
                   ratePerHour = product.rate_per_hour,
                   timeStudyPerTest = product.time_study_per_test
                };
            }
            else
            {
                throw new McpCustomException("This product doesn't exist");
            }
        }

        public List<AllProductsResponseModel> getProductsByFocusArea(string focusArea)
        {
            try
            {
                FocusAreaEntity FA = _focusAreaRepo.GetByName(focusArea);
                if(FA != null)
                {
                    List<ProductsEntity> productsEntity = _productRepo.GetByFocusArea(FA.id);
                    List<AllProductsResponseModel> result = new List<AllProductsResponseModel>();
                    foreach (ProductsEntity prod in productsEntity)
                    {
                            AllProductsResponseModel product = new AllProductsResponseModel();
                            product.focusAreaId = prod.focus_area_fk;
                            product.item = prod.name;
                            product.productId = prod.id;
                            product.ratePerHour = prod.rate_per_hour;
                            product.timeStudyPerTest = prod.time_study_per_test;
                            result.Add(product);
                    }
                    return result;
                }
                else
                {
                    throw new McpCustomException("Cannot find focus area: " + focusArea);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool updateProduct(ProductRequestModel product)
        {
            if (_productRepo.GetById(product.id) != null)
            {
                ProductsEntity p = _entityBuilder.buildProductEntity(product.id, product.name, product.timeStudyPerTest, product.ratePerHour, product.focusArea);
                return _productRepo.Update(p);
            }
            else
            {
                throw new McpCustomException("This product doesn't exist");
            }
        }
    }
}
