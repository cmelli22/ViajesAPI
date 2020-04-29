﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}