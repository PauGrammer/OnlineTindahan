using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OnlineTindahan.Models;
using OnlineTindahan.DataAccessLayer;

namespace OnlineTindahan.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("AllProducts");
        }

        [Route("Products/Details/{productID?}")] 
        public ActionResult Details(int productID)
        {
            var dal = new ProductsDAL();
            var productDetails = dal.GetProductByID(productID);
            if (!dal.IsSuccessful)
            {
                return new HttpNotFoundResult(dal.ErrorMessage);
            }
            return View(productDetails);
        }

        public ActionResult AllProducts()
        {
            var dal = new ProductsDAL();
            var productList = dal.GetProductList();
            if (!dal.IsSuccessful)
            {
                return new HttpNotFoundResult(dal.ErrorMessage);
            }
            return View(productList);
        }
    }
}