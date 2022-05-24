using Newtonsoft.Json;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class ProductDetailsBrowseController : Controller
    {
        // GET: ProductDetailsBrowse
        public ActionResult ProductDetails(string productName)
        {
            var productModel = GetProductDetails();
            return View(productModel);
        }

        [OutputCache(Duration = 3600, VaryByParam = "categoryId",Location =System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult ViewProduct(long categoryId)
        {
            //long categoryId = 1;
            var output = GetProductDetailFromCategory(categoryId);
            return View(output);
        }

        public ActionResult AddToCart(long productId,string productName)
        {
            ViewBag.ProductName = productName;
            UpdateOrder(productId);
            return View();
        }
        private IEnumerable<ProductDetailModel> GetProductDetails()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:900/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("api/ProductModel");
            var output = response.Result.Content.ReadAsAsync<IEnumerable<ProductDetailModel>>().Result;
            return output;
        }

        private IEnumerable<ProductDetailModel> GetProductDetailFromCategory(long categoryId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:900/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("api/ProductModel/"+ categoryId);
            var output = response.Result.Content.ReadAsAsync<IEnumerable<ProductDetailModel>>().Result;
            return output;
        }

        private async Task UpdateOrder(long productId)
        {
            var productToUpdate = JsonConvert.SerializeObject(productId);
            var requestContent = new StringContent(productToUpdate, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:900/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync("api/ProductModel/", requestContent);
            response.EnsureSuccessStatusCode();
        }
    }
}