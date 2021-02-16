using API.Core.DataModels;
using API.Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductController(StoreContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var productAll = await _context.Products.ToListAsync();

            return productAll;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>>Get(int id)
        {
            var product =await  _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            return product;
        }




    }
}
