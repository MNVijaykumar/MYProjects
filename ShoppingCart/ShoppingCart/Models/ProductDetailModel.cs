using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class ProductDetailModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public byte[] ImageData { get; set; }
    }
}