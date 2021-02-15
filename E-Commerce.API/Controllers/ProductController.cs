using DAL.API.DataContext;
using DAL.API.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<List<Product>> GetAll()
        {
            var productAll =  _context.Products.ToList();

            return productAll;
        }

        [HttpGet("{id}")]
        public  ActionResult<Product> Get(int id)
        {
            var product =  _context.Products.FirstOrDefault(p => p.Id == id);

            return product;
        }




    }
}
