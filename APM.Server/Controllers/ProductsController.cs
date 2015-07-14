using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using APM.Server.Models;

namespace APM.Server.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ProductsController : ApiController
    {        
        // GET: api/Products        
        public IEnumerable<Product> Get()
        {
            var ps = new ProductRepository();
            return ps.Retrieve();
        }

        // GET: api/Products/FFQ        
        public IEnumerable<Product> Get(string search)
        {            
            var pr = new ProductRepository();
            return pr.Retrieve().Where(p => p.ProductCode.Contains(search));            
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
