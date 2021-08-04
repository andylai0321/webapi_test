using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Models.Products> Get()
        {
            Repository.Get_Products getproducts = new Repository.Get_Products();
            return getproducts.Get_ProductsList("");
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        //public string Get(int id)
        public IEnumerable<Models.Products> Get(int id)
        {
            Repository.Get_Products getproducts = new Repository.Get_Products();
            return getproducts.Get_ProductsList(id.ToString());
        }

        // POST api/<ProductsController>
        [HttpPost]
        //public void Post([FromBody] string value)
        public string Post([FromBody] Models.Products p)
        {
            Dictionary<string, string> valueset = new Dictionary<string, string>();
            
            //return p.ProductID.ToString();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
