using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayerAPI.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long CategoryId { get; set; }
    }

    public class ProductDetailModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long Total { get; set; }
        public long Ordered { get; set; }
        public decimal CostPerUnit { get; set; }
    }

    public class ProductDetailViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Total { get; set; }
        public long Ordered { get; set; }
        public decimal CostPerUnit { get; set; }
    }

    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
    }
}