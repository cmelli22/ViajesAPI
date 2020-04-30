using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViajesAPI.Models.Entities;
using ViajesAPI.Reponse;
using ViajesAPI.Repositories.Interfaces;
using ViajesAPI.Services.Interfaces;
using ViajesAPI.UnitOfWorks;

namespace ViajesAPI.Services.Implementations
{
    public class ProductService: IProductService
    {
        private readonly IProdcutRepository _productRepository;
        private readonly IUnitOfWorks _unitOfWork;

        public ProductService(IProdcutRepository productRepository, IUnitOfWorks unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Product>> GetAll()
        {
            try
            {
                var Products = await _productRepository.GetAll();
                if(Products != null)
                {
                    return new BaseResponse<Product>(Products);
                }
                else
                {
                    return new BaseResponse<Product>("No se encontraron Productos");
                }
 
            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>(ex.Message);
            }
          

        }
        public async Task<BaseResponse<Product>> GetById(Guid id)
        {
            try
            {
                var product = await _productRepository.GetById(id);
                if(product != null)
                {
                    return new BaseResponse<Product>(product);
                }
                else
                {
                    return new BaseResponse<Product>("No se encontro el producto");
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>(ex.Message);   
            }
        }
        public async Task<BaseResponse<Product>> Add(Product product)
        {
            try
            {
                await _productRepository.Add(product);
                await _unitOfWork.SaveChanges();
                return new BaseResponse<Product>(product);

            }
            catch (Exception ex)
            {
                return new BaseResponse<Product>(ex.Message);
            }
        }
        public async Task<BaseResponse<Product>> Delete(Product product)
        {
            var existeProducto = await this.GetById(product.productId);
            if(existeProducto.data != null) 
            {
                try
                {
                    _productRepository.Delete(product);
                    await _unitOfWork.SaveChanges();
                    return new BaseResponse<Product>(product);
                }
                catch (Exception ex)
                {
                    return new BaseResponse<Product>(ex.Message);
                }
            }
            else
            {
                return new BaseResponse<Product>(existeProducto.message);
            }

        }
    }
}
