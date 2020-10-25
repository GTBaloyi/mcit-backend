using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Exceptions;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("focusAreas")]
        public ActionResult<List<FocusAreaModel>> GetAllFocusAreas()
        {
            try
            {
                return StatusCode(200, _productService.getAllFocusAreas());
            } 
            catch(Exception)
            {
                return StatusCode(500, "External Server Error");
            }
        }

        [HttpGet("focusAreas/{name}")]
        public ActionResult<FocusAreaModel> GetFocusArea(string name)
        {
            try
            {
                return StatusCode(200, _productService.getFocusArea(name));
            }
            catch(McpCustomException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "External Server Error");
            }
        }

        [HttpGet("product/{name}")]
        public ActionResult<AllProductsResponseModel> GetProduct(string name)
        {
            try
            {
                return StatusCode(200, _productService.getProductByName(name));
            }
            catch (McpCustomException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "External Server Error");
            }
        }

        [HttpGet("products")]
        public ActionResult<List<AllProductsResponseModel>> GetAllProducts()
        {
            try
            {
                return StatusCode(200, _productService.getAllProducts());
            }
            catch (Exception)
            {
                return StatusCode(500, "External Server Error");
            }
        }

        [HttpGet("products/{focusArea}")]
        public ActionResult<List<AllProductsResponseModel>> GetProductsByFocusArea(string focusArea)
        {
            try
            {
                return StatusCode(200, _productService.getProductsByFocusArea(focusArea));
            }
            catch(McpCustomException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch(Exception)
            {
                return StatusCode(500, "External Server Error");
            }
        }

        [HttpPost("products")]
        public ActionResult CreateProduct([FromBody] ProductRequestModel product)
        {
            try
            {
                if(_productService.createProduct(product))
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Could not create product");
                }
                
            }
            catch (Exception)
            {
                return StatusCode(500, "External Server Error");
            }
        }

        [HttpPost("products/{focusAreaName}")]
        public ActionResult CreateFocusArea(string focusAreaName)
        {
            try
            {
                if (_productService.createFocusArea(focusAreaName))
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Could not create focus area");
                }

            }
            catch (Exception)
            {
                return StatusCode(500, "External Server Error");
            }
        }


        [HttpPut("products")]
        public ActionResult UpdateProduct([FromBody] ProductRequestModel product)
        {
            try
            {
                if (_productService.updateProduct(product))
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Could not update product");
                }

            }
            catch (McpCustomException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "External Server Error");
            }
        }

        [HttpPut("focus-area")]
        public ActionResult UpdateFocusArea([FromBody] FocusAreaModel focusArea)
        {
            try
            {
                if (_productService.updateFocusArea(focusArea))
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Could not update product");
                }

            }
            catch (McpCustomException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "External Server Error");
            }
        }

        [HttpDelete("products/{productID}")]
        public ActionResult DeleteProduct(int productID)
        {
            try
            {
                if (_productService.deleteProduct(productID))
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Could not delete product");
                }

            }
            catch (McpCustomException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "External Server Error");
            }
        }

        [HttpDelete("products/focusArea")]
        public ActionResult DeleteProduct(string focusArea)
        {
            try
            {
                if (_productService.deleteFocusArea(focusArea))
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Could not delete focus area");
                }

            }
            catch (McpCustomException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "External Server Error");
            }
        }
    }
}