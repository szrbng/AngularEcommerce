using API.Core.DataModels;
using API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        public ProductController(IGenericRepository<Product> productRepository,
         IGenericRepository<ProductBrand> productBrandRepository,
         IGenericRepository<ProductType> productTypeRepository)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var productAll = await _productRepository.ListAllAsync();

            return Ok(productAll);
        }

       
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>>GetProduct(int id)
        {
            var productById = await _productRepository.GetByIdAsync(id);

            return Ok(productById);
        }

        
        [HttpGet("/{brands}")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductsBrands()
        {
            var productbrand = await _productBrandRepository.ListAllAsync();

            return Ok(productbrand);
        }

        [HttpGet("api/product/{types}")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsTypes()
        {
            var producttype = await _productTypeRepository.ListAllAsync();

            return Ok(producttype);
        }




    }
}
