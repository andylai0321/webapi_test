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
    public class SystemsController : ControllerBase
    {
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Models.systems> Get()
        {
            Repository.Get_systems getproducts = new Repository.Get_systems();
            return getproducts.Get_SystemsList("");
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        //public string Get(int id)
        public IEnumerable<Models.systems> Get(int id)
        {
            Repository.Get_systems getproducts = new Repository.Get_systems();
            return getproducts.Get_SystemsList(id.ToString());
        }

        // POST api/<ProductsController>
        [HttpPost]
        //public void Post([FromBody] string value)
        //public string Post([FromBody] Models.Products p)
        public IEnumerable<Models.systems> Post([FromBody] Models.systems p)
        {
            Dictionary<string, string> valueset = new Dictionary<string, string>();
            foreach(var prop in p.GetType().GetProperties())
            {
                valueset.Add(prop.Name, prop.GetValue(p).ToString());
            }
            Repository.Get_systems getproducts = new Repository.Get_systems();
            return getproducts.Get_SystemsList(valueset);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        public System.Net.Http.HttpResponseMessage Put(int id, [FromBody] Models.systems p)
        {
            Dictionary<string, string> valueset = new Dictionary<string, string>();
            foreach (var prop in p.GetType().GetProperties())
            {
                valueset.Add(prop.Name, prop.GetValue(p).ToString());
            }
            Repository.Get_systems getproducts = new Repository.Get_systems();
            return getproducts.update_systemlist(id.ToString(), valueset);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        //public void Delete(int id)
        public System.Net.Http.HttpResponseMessage Delete(int id)
        {
            Repository.Get_systems getproducts = new Repository.Get_systems();
            return  getproducts.delete_systemlist(id.ToString());
        }
    }
}
