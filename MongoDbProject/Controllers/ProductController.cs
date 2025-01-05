using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Models;
using MongoDbProject.Services;

namespace MongoDbProject.Controllers
{
    public class ProductController : Controller
    {
        ProductOperation productOperation = new ProductOperation();

        public IActionResult Index()
        {
            return View(productOperation.ProductList());
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddProduct(Product product)
        {
            var value = new Product
            {
                Category = product.Category,
                Price = product.Price,
                ProductName = product.ProductName,
                Unit = product.Unit
            };

            productOperation.AddProduct(value);

            return RedirectToAction("Index");
        }

     
        public IActionResult RemoveProduct(string id)
        {
            Product product = new Product
            {
                ProductId = id
            };

            if (product != null)
            {
                productOperation.DeleteProduct(product.ToString());
            }

            return RedirectToAction("Index");
        }

        public IActionResult UpdateProduct(Product product)
        {
            Product product1 = new Product()
            {
                Category = product.Category,
                Price = product.Price,
                ProductName = product.ProductName,
                Unit = product.Unit,
                ProductId = product.ProductId
            };

            productOperation.UpdateProduct(product1);

            return RedirectToAction("Index");
        }
    }
}
