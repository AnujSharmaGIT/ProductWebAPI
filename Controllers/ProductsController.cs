using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using ProductWebAPI.Models;


namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : Controller
    {
        private Productdbcontext _dbcontext;

        public ProductsController(Productdbcontext dbContext)

        { _dbcontext = dbContext; }

        [HttpGet]
        // GET: ProductsController
        public IEnumerable<Product> Get()
        {
            return _dbcontext.Products;
        }

        // GET: ProductsController/Details/5
        public Product Get(int id)
        {
            var product = _dbcontext.Products.Find(id);
            return product;
        }

        // POST: ProductsController/Create
        [HttpPost]
        public void Post(Product product)
        {
            _dbcontext.Products.Add(product);
            _dbcontext.SaveChanges();
        }

        // POST: ProductsController/Create


        // PUT: ProductsController/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Product productobj) //async APIs 
        {
            var prod = await _dbcontext.Products.FindAsync(id);
            if (prod == null)
            {
                return NotFound("No such record found against the ID");
            }

            else
            {
                prod.Name = productobj.Name;
                prod.Desc = productobj.Desc;
                prod.Price = productobj.Price;
               await _dbcontext.SaveChangesAsync();
                return Ok("Records updated");
            }
         

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) //async APIs 
        {
            var product = await _dbcontext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound("No such record found for delete");
            }

            else
            {
                _dbcontext.Products.Remove(product);
              await  _dbcontext.SaveChangesAsync();
                return Ok("Record deleted");
            }

           
        }



    }
}
