using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.Exceptions;
using backend.Models.Response;
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
        public ProductService(IFocusAreaRepository focusAreaRepo, IProductRepository productRepository)
        {
            _focusAreaRepo = focusAreaRepo;
            _productRepo = productRepository;
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
    }
}
