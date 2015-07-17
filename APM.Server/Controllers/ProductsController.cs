using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.OData;
using APM.Server.Models;
using Newtonsoft.Json;

namespace APM.Server.Controllers
{    
    [EnableCors("http://localhost:6203", "*", "*")]
    public class ProductsController : ApiController
    {        
        // GET: api/Products       
        //EnableQuery needs for OData query        
        [EnableQuery()]
        [ResponseType(typeof(IQueryable<Product>))]
        public IHttpActionResult Get()
        {
            try
            {
                
                var ps = new ProductRepository();
                return Ok(ps.Retrieve()
                    .AsQueryable());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //// GET: api/Products/FFQ              
        //public IEnumerable<Product> Get(string search)
        //{            
        //    var pr = new ProductRepository();
        //    //AsQueryable(); need for OData query
        //    return pr.Retrieve()
        //        .Where(p => p.ProductCode.Contains(search));
        //}

        // GET: api/Products/FFQ              
        [Authorize()]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get(int id)
        {
            try
            {                
                Product product;
                var pr = new ProductRepository();

                if (id > 0)
                {
                    var products = pr.Retrieve();
                    product = products.FirstOrDefault(p => p.ProductId == id);
                    if (product == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    product = pr.Create();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Products
        public IHttpActionResult Post([FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var pr = new ProductRepository();
                var newProduct = pr.Save(product);
                if (newProduct == null)
                {
                    return Conflict();
                }
                return Created(Request.RequestUri + newProduct.ProductId.ToString(), newProduct);            
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);                
            }
        }

        // PUT: api/Products/5
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var pr = new ProductRepository();
                var updateProduct = pr.Save(id, product);
                if (updateProduct == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                throw;
            }
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {            
        }
    }
}
