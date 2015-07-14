using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using APM.Server.Models;

namespace APM.Server.Controllers
{
    public class ProductsController : ApiController
    {
        [EnableCors("*","*", "*")]
        // GET: api/Products        
        public IEnumerable<Product> Get()
        {
            var ps = new ProductRepository();
            return ps.Retrieve();
        }

        // GET: api/Products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
