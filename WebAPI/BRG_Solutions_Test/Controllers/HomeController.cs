using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BRG_Solutions_Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BRG_Solutions_Test.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ApplicationContext db = new ApplicationContext();

        [HttpGet]
        [Route("GetCategories")]
        //GET : /api/Home/GetCategories
        public IQueryable GetCategories()
        {
            return db.CategoryProducts;
        }

        [HttpPost]
        [Route("AddProduct")]
        //POST : /api/Home/AddProduct
        public async Task<Object> AddProduct(AddProductModel model)
        {
            if (model.ProductName.Length==0 || model.CategoryProductId == 0)
            {
                return BadRequest(new { message = "ProductName or Category is incorrect." });
            }
            Product product = new Product
            {
                ProductName = model.ProductName,
                CategoryProductId = model.CategoryProductId
            };
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();

            return Ok();

        }

        [HttpGet]
        [Route("GetProducts")]
        //GET : /api/Home/GetProducts
        public IQueryable GetProducts()
        {
            var productList = db.Products.Select(p => new
            {
                p.Id,
                p.ProductName,
                Category = p.Category.CategoryName
            });

            return productList;
        }
    }
}