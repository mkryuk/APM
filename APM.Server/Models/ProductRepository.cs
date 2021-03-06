﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using Newtonsoft.Json;

namespace APM.Server.Models
{
    public class ProductRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal Product Create()
        {
            return new Product() {ReleaseDate = DateTime.Now};
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal List<Product> Retrieve()
        {
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/product.json");
            var json = System.IO.File.ReadAllText(filePath);
            var products = JsonConvert.DeserializeObject<List<Product>>(json);
            return products;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        internal Product Save(Product product)
        {
            var products = this.Retrieve();
            var maxId = products.Max(p => p.ProductId);
            product.ProductId = maxId + 1;
            products.Add(product);

            WriteData(products);
            return product;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        internal Product Save(int id, Product product)
        {
            var products = this.Retrieve();
            var itemIndex = products.FindIndex(p => p.ProductId == product.ProductId);            
            if (itemIndex >= 0)
            {
                products[itemIndex] = product;
            }
            else
            {
                return null;
            }
            WriteData(products);
            return product;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        private bool WriteData(List<Product> products)
        {
            var filepath = HostingEnvironment.MapPath(@"~/App_Data/product.json");
            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            System.IO.File.WriteAllText(filepath, json);
            return true;
        }
    }
}