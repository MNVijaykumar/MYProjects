using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoppingCart.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Category()
        {
            return View();
        }
        public ActionResult ViewSingleProduct(long categoryId)
        {
            return RedirectToAction("ViewProduct", "ProductDetailsBrowse",new { categoryId = categoryId });
        }
    }
}