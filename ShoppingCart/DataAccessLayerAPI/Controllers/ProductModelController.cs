using DataAccessLayerAPI.DAL;
using DataAccessLayerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataAccessLayerAPI.Controllers
{
    [RoutePrefix("api/ProductModel")]
    public class ProductModelController : ApiController
    {
        // GET api/<controller>
        [Route()]
        public IEnumerable<ProductDetailViewModel> Get()
        {
            DALFROMExcel dal = new DALFROMExcel();
            var output = dal.GetProducts();
            return output;
        }

        //[HttpGet]
        //[Route("{categoryId}", Name = "GetProduct")]
        //public IEnumerable<ProductDetailViewModel> GetProductPerCategory(long categoryId)
        //{
        //    DALFROMExcel dal = new DALFROMExcel();
        //    var output = dal.GetProductsPerCategory(categoryId);
        //    return output;
        //}

        [HttpGet]
        [Route("{categoryId}", Name = "GetProductFromDB")]
        public IEnumerable<ProductViewModel> GetProductPerCategoryFromDB(long categoryId)
        {
            DALFromDB dal = new DALFromDB();
            var output = dal.GetProductsPerCategory(categoryId);
            return output;
        }

        [HttpPost]
        [Route(Name = "UpdateOrderDetails")]
        public void UpdateOrderDetails([FromBody]long productId)
        {
            DALFromDB dal = new DALFromDB();
            dal.UpdateOrder(productId);
        }
    }
}