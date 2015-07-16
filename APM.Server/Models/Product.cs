using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APM.Server.Models
{
    public class Product
    {
        public string Description { get; set; }
        public decimal Price  { get; set; }
        public string ProductCode { get; set; }
        public int ProductId { get; set; }
        [Required(ErrorMessage = "ProductName is required", AllowEmptyStrings = false)]
        [MinLength(5, ErrorMessage = "ProductName is too small")]
        [MaxLength(11, ErrorMessage = "ProductName is too large")]
        public string ProductName { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}