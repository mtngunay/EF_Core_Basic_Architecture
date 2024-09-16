using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Data;
using Web.Data.Services;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICrudService<Product> _productService;

        public HomeController(ICrudService<Product> productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
