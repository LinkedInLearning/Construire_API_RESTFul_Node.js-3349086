using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkedInLearning.REST.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkedInLearning.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products = new List<Product> {
            new Product { Id = 0, Name = "T-shirt", Description = "Un T-shirt", Quantity = 5 },
            new Product { Id = 1, Name = "Pull", Description = "Un Pull", Quantity = 18 },
            new Product { Id = 2, Name = "Chemise", Description = "Une chemise", Quantity = 21 },
            new Product { Id = 3, Name = "Jeans", Description = "Un jeans", Quantity = 2 }
        };

        [HttpGet]
        public IActionResult Get([FromQuery] int offset, [FromQuery] int limit)
        {
            if (limit == 0)
                limit = 1;

            return Ok(_products.Skip(offset).Take(limit));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            var product = _products.Find(item => item.Id == id);

            return product == null ? NotFound() : Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] Product product)
        {
            var index = _products.FindIndex(item => item.Id == id);

            _products[index] = product;

            return Ok(product);
        }

        [HttpGet("cached/{id}")]
        [ETagFilter]
        public IActionResult GetCached(int? id)
        {
            var product = _products.Find(item => item.Id == id);

            return product == null ? NotFound() : Ok(product);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
    }
}