using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Exceptions;
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
        public ActionResult<AllProductsResponseModel> GetProductsByFocusArea(string focusArea)
        {
            try
            {
                return StatusCode(200, _productService.getProductsByFocusArea(focusArea));
            }
            catch(McpCustomException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "External Server Error");
            }
        }
    }
}