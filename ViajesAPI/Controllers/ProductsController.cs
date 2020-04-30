using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajesAPI.Models.Entities;
using ViajesAPI.Services.Interfaces;

namespace ViajesAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productService.GetAll();
            if (!response.status)
            {
                return NotFound(response.message);
            }
            else
            {
                return Ok(response.dataList);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var response = await _productService.GetById(id);
            if (!response.status)
            {
                return NotFound(response.message);
            }
            else
            {
                return Ok(response.data);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var response = await _productService.Add(product);
                if (!response.status)
                {
                    return NotFound(response.message);
                }
                else
                {
                    return Ok(response);
                }

            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var response = await _productService.Delete(product);
                if (!response.status)
                {
                    return NotFound(response.message);
                }
                else
                {
                    return Ok("El producto fue eliminado correctamente");
                }
            }

        }
    }
}